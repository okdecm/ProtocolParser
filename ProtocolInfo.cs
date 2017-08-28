using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeaderProtocolParser
{
	[Serializable]
	public class ProtocolInfo
	{
		public string path = "";
		public List<ProtocolGroup> protocolGroups = new List<ProtocolGroup>();

		private string enumRegexStringPattern = @"(?:enum\s+(?:[ a-zA-Z0-9().:*_-]*){0}\s*\{{\s)([^}};]*.*)\}};";

		private Dictionary<string, string> groupNamesAliases = new Dictionary<string, string>()
		{
			{
				"KQ",
				"KINGDOMQUEST"
			},
			{
				"WT",
				"WEAPONTITLE"
			},
			{
				"CT",
				"CHARACTERTITLE"
			},
			{
				"HOLY_PROMISE",
				"HOLYPROMISE"
			},
			{
				"MID",
				"MATCH_INSTANCE_DUNGEON"
			}
		};

		public static ProtocolInfo LoadFromHeader(string path, BackgroundWorker backgroundWorker = null)
		{
			ProtocolInfo protocolInfo = new ProtocolInfo();

			protocolInfo.path = path;

			string content = File.ReadAllText(path);

			protocolInfo.PopulateGroups(content, backgroundWorker);

			return protocolInfo;
		}

		public void PopulateGroups(string content, BackgroundWorker backgroundWorker = null)
		{
			backgroundWorker?.ReportProgress(0, this);

			Regex protocolGroupsRegex = new Regex(String.Format(enumRegexStringPattern, "PROTOCOL_COMMAND"));

			Match protocolGroupsRegexMatch = protocolGroupsRegex.Match(content);

			if (protocolGroupsRegexMatch.Groups.Count > 1)
			{
				string[] values = protocolGroupsRegexMatch.Groups[1].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).Where(x => !string.IsNullOrEmpty(x)).ToArray();

				Int32 loadedGroupCount = 0;

				foreach (string value in values)
				{
					string[] groupNameByValue = value.Trim().Replace(",", "").Split(new string[] { " = " }, StringSplitOptions.None);

					if (groupNameByValue.Length > 1)
					{
						ProtocolGroup protocolGroup = new ProtocolGroup(groupNameByValue[0], groupNameByValue[1]);

						backgroundWorker?.ReportProgress((loadedGroupCount / values.Length), protocolGroup);

						protocolGroup.PopulateProtocols(content, groupNamesAliases, backgroundWorker);

						protocolGroups.Add(protocolGroup);
					}

					loadedGroupCount++;
				}
			}

			backgroundWorker?.ReportProgress(100, this);
		}

		public static ProtocolInfo Import(string path)
		{
			return Import(File.ReadAllBytes(path));
		}

		public static ProtocolInfo Import(byte[] data)
		{
			ProtocolInfo protocolInfo;

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			using (MemoryStream memoryStream = new MemoryStream(data))
			{
				protocolInfo = (ProtocolInfo)binaryFormatter.Deserialize(memoryStream);
			}

			return protocolInfo;
		}

		public void Export(string path)
		{
			File.WriteAllBytes(path, Export());
		}

		public byte[] Export()
		{
			byte[] data;

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			using (MemoryStream memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, this);
				data = memoryStream.ToArray();
			}

			return data;
		}

		[Serializable]
		public class ProtocolGroup
		{
			public string name { get; set; }
			public string value { get; set; }

			public bool protocolsNotFound { get; set; } = true;

			public List<Protocol> protocols = new List<Protocol>();

			private string enumRegexStringPattern = @"(?:enum\s+(?:[ a-zA-Z0-9().:*_-]*){0}\s*\{{\s)([^}};]*.*)\}};";

			public ProtocolGroup(string name, string value)
			{
				this.name = name;
				this.value = value;
			}

			public void PopulateProtocols(string content, Dictionary<string, string> groupNamesAliases, BackgroundWorker backgroundWorker = null)
			{
				string enumName = name.Replace("NC_", "");

				if (groupNamesAliases.ContainsKey(enumName))
				{
					enumName = groupNamesAliases[enumName];
				}

				Regex protocolsRegex = new Regex(String.Format(enumRegexStringPattern, $"PROTOCOL_COMMAND_{enumName}"));

				Match protocolsRegexMatch = protocolsRegex.Match(content);

				if (protocolsRegexMatch.Groups.Count > 1)
				{
					protocolsNotFound = false;

					string[] values = protocolsRegexMatch.Groups[1].ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None).Where(x => !string.IsNullOrEmpty(x)).ToArray();

					Int32 loadedProtocolCount = 0;

					foreach (string value in values)
					{
						string[] groupNameByValue = value.Trim().Replace(",", "").Split(new string[] { " = " }, StringSplitOptions.None).Where(x => !string.IsNullOrEmpty(x)).ToArray();

						if (groupNameByValue.Length > 1)
						{
							Protocol protocol = new Protocol(groupNameByValue[0], groupNameByValue[1]);
							
							protocol.PopulateDetails(content);

							backgroundWorker?.ReportProgress((loadedProtocolCount / values.Length), protocol);

							protocols.Add(protocol);
						}

						loadedProtocolCount++;
					}
				}
			}

			[Serializable]
			public class Protocol
			{
				public string name { get; set; }
				public string value { get; set; }

				public string details { get; set; }

				public bool detailsNotFound { get; set; } = true;
				public Int32 detailsOccurencesFound { get; set; } = 0;

				//private string anythingRegexStringPattern = @"(?:(?:.*)\s+(?:.*){0}(?:.*)\s*\{{)(\s+.*\n*)*(?=[^{{}}]*\}})\}};";
				//private string anythingRegexStringPattern = @"(?:[ a-zA-Z0-9().:*_-]*)(?:\s+\**{0}\s*\{{)(\s+.*\n*)*(?=[^{{}}]*\}})\}};";
				//private string anythingRegexStringPattern = @"(?:struct\s+([ a-zA-Z0-9().:*_-]*){0}\s*\{{)(\s+.*\n*)*(?=[^{{}}]*\}})\}};";
				private string structRegexStringPattern = @"(?:struct\s+(?:[ a-zA-Z0-9().:*_-]*){0}\s*\{{\s)(?:(?!\}};)(.*\s))*\}};";

				public Protocol(string name, string value)
				{
					this.name = name;
					this.value = value;
				}

				public void PopulateDetails(string content)
				{
					List<string> newDetails = new List<string>();

					string protocolName = name;

					Regex detailsRegex = new Regex(String.Format(structRegexStringPattern, $"PROTO_{protocolName}"));

					MatchCollection detailsRegexMatches = detailsRegex.Matches(content);

					if (detailsRegexMatches.Count > 0)
					{
						detailsNotFound = false;
						
						foreach (Match detailsRegexMatch in detailsRegexMatches)
						{
							newDetails.Add(detailsRegexMatch.Value);
						}

						details = string.Join(Environment.NewLine + Environment.NewLine, newDetails);
					}
					else
					{
						Int32 occurencesCount = content.Split(new string[] { $"PROTO_{protocolName}" }, StringSplitOptions.None).Length - 1;
						
						detailsOccurencesFound = occurencesCount;
					}
				}
			}
		}
	}
}