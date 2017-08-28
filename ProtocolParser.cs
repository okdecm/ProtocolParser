using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeaderProtocolParser
{
	public partial class fProtocolParser : Form
	{
		ProtocolInfo protocolInfo;

		public fProtocolParser()
		{
			InitializeComponent();
		}

		private void miMenuFileOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Title = "Open Protocol Info File";
			openFileDialog.Filter = "ERB Files|*.erb|Header Files|*.h";

			openFileDialog.InitialDirectory = @"D:\Projects\Fiesta\Resources";

			DialogResult dialogResult = openFileDialog.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				string extension = Path.GetExtension(openFileDialog.FileName).Replace(".", "");

				switch (extension.ToLower())
				{
					case "h":
						LoadHeaderFile(openFileDialog.FileName);
						break;

					case "erb":
						protocolInfo = ProtocolInfo.Import(openFileDialog.FileName);
						DisplayProtocolInfo();
						break;
				}

			}
		}

		private void tvProtocols_AfterSelect(object sender, TreeViewEventArgs e)
		{
			ProtocolInfo.ProtocolGroup.Protocol protocol = tvProtocols.SelectedNode.Tag as ProtocolInfo.ProtocolGroup.Protocol;

			if (protocol != null)
			{
				rtbProtocolDetails.Text = protocol.details;
			}
			else
			{
				rtbProtocolDetails.Text = "";
			}
		}

		private void miFileExportERB_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();

			saveFileDialog.Title = "Save ERB File";
			saveFileDialog.Filter = "ERB Files|*.erb";

			saveFileDialog.InitialDirectory = @"D:\Projects\Fiesta\Resources";

			DialogResult dialogResult = saveFileDialog.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				protocolInfo.Export(saveFileDialog.FileName);
			}
		}

		private void miFileExportCSharpClasses_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

			DialogResult dialogResult = folderBrowserDialog.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				foreach (ProtocolInfo.ProtocolGroup protocolGroup in protocolInfo.protocolGroups)
				{
					List<string> protocols = new List<string>();

					foreach (ProtocolInfo.ProtocolGroup.Protocol protocol in protocolGroup.protocols)
					{
						string name = protocol.name.Replace($"{protocolGroup.name}_", "");

						if (name.StartsWith("2"))
						{
							name = name.Substring(1);
							name = $"TO_{name}";
						}

						protocols.Add(String.Format("\t\t{0} = 0x{1}{2},", name, protocolGroup.value.Replace("0x", "").PadLeft(2, '0'), protocol.value.Replace("0x", "").PadLeft(2, '0')));
					}

					string content = "using System;\r\n\r\nnamespace {0}\r\n{{\r\n\tpublic enum {1} : UInt16\r\n\t{{\r\n{2}\r\n\t}}\r\n}}";

					content = String.Format(content, "Fiesta.Game.Networking.PacketTypes", protocolGroup.name.Replace("NC_", ""), string.Join(Environment.NewLine, protocols));

					File.WriteAllText(String.Format("{0}\\{1}.cs", folderBrowserDialog.SelectedPath, protocolGroup.name.Replace("NC_", "")), content);
				}
			}
		}

		private void miEditOrderByValue_Click(object sender, EventArgs e)
		{
			if (protocolInfo != null)
			{
				protocolInfo.protocolGroups = protocolInfo.protocolGroups.OrderBy(x => int.Parse(x.value.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber)).ToList();

				foreach (ProtocolInfo.ProtocolGroup protocolGroup in protocolInfo.protocolGroups)
				{
					protocolGroup.protocols = protocolGroup.protocols.OrderBy(x => int.Parse(x.value.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber)).ToList();
				}

				DisplayProtocolInfo();
			}
		}

		private void tbResultsSearch_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (tbResultsSearch.Text.Length > 0)
				{
					Int32 searchFor = (Int32)new Int32Converter().ConvertFromString(tbResultsSearch.Text);

					byte group = (byte)(searchFor >> 0x8);
					byte type = (byte)(searchFor & 0xFF);

					ProtocolInfo.ProtocolGroup protocolGroup = protocolInfo.protocolGroups.First(x => byte.Parse(x.value.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber) == group);

					if (protocolGroup != null)
					{
						TreeNode parentTreeNode = tvProtocols.Nodes.Cast<TreeNode>().Where(x => x.Tag == protocolGroup).First();

						if (parentTreeNode != null)
						{
							ProtocolInfo.ProtocolGroup.Protocol protocol = protocolGroup.protocols.First(x => byte.Parse(x.value.Replace("0x", ""), System.Globalization.NumberStyles.HexNumber) == type);

							if (protocol != null)
							{
								TreeNode childTreeNode = parentTreeNode.Nodes.Cast<TreeNode>().Where(x => x.Tag == protocol).First();

								if (childTreeNode != null)
								{
									tvProtocols.SelectedNode = childTreeNode;
								}
							}
							else
							{
								tvProtocols.SelectedNode = parentTreeNode;
							}
						}
					}
				}

				tvProtocols.Focus();
			}
		}

		private void tstbByDec_Enter(object sender, EventArgs e)
		{
			tstbByDec.Text = "... And Erblin";
		}

		private void tstbByDec_Leave(object sender, EventArgs e)
		{
			tstbByDec.Text = "By Dec";
		}

		private void DisplayProtocolInfo()
		{
			tvProtocols.Nodes.Clear();

			if (protocolInfo != null)
			{
				foreach (ProtocolInfo.ProtocolGroup protocolGroup in protocolInfo.protocolGroups)
				{
					TreeNode protocolGroupTreeNode = new TreeNode(String.Format("{0} ({1})", protocolGroup.name, protocolGroup.value));

					protocolGroupTreeNode.Tag = protocolGroup;

					if (protocolGroup.protocolsNotFound)
					{
						protocolGroupTreeNode.BackColor = Color.Red;
					}

					foreach (ProtocolInfo.ProtocolGroup.Protocol protocol in protocolGroup.protocols)
					{
						TreeNode protocolTreeNode = new TreeNode(String.Format("{0} ({1})", protocol.name, protocol.value));

						protocolTreeNode.Tag = protocol;

						if (protocol.detailsNotFound)
						{
							if (protocol.detailsOccurencesFound > 0)
							{
								protocolTreeNode.BackColor = Color.Orange;
							}
							else
							{
								protocolTreeNode.BackColor = Color.Red;
							}
						}

						protocolGroupTreeNode.Nodes.Add(protocolTreeNode);
					}

					tvProtocols.Nodes.Add(protocolGroupTreeNode);
				}
			}
		}

		private void LoadHeaderFile(string path)
		{
			tvProtocols.Nodes.Clear();

			BackgroundWorker backgroundWorker = new BackgroundWorker();

			backgroundWorker.WorkerReportsProgress = true;

			backgroundWorker.DoWork += (doWorkSender, doWorkEventArgs) =>
			{
				protocolInfo = ProtocolInfo.LoadFromHeader(path, (BackgroundWorker)doWorkSender);
			};

			TreeNode lastProtocolGroupTreeNode = null;

			backgroundWorker.ProgressChanged += (doWorkSender, doWorkEventArgs) =>
			{
				if (doWorkEventArgs.UserState != null)
				{
					if (doWorkEventArgs.UserState is ProtocolInfo)
					{
						tsslStatus.Text = String.Format("Loading Protocol Info {0}", ((ProtocolInfo)doWorkEventArgs.UserState).path);
					}
					else if (doWorkEventArgs.UserState is ProtocolInfo.ProtocolGroup)
					{
						ProtocolInfo.ProtocolGroup protocolGroup = ((ProtocolInfo.ProtocolGroup)doWorkEventArgs.UserState);

						TreeNode protocolGroupTreeNode = new TreeNode(String.Format("{0} ({1})", protocolGroup.name, protocolGroup.value));

						protocolGroupTreeNode.Tag = protocolGroup;

						if (protocolGroup.protocolsNotFound)
						{
							protocolGroupTreeNode.BackColor = Color.Red;
						}

						tvProtocols.Nodes.Add(protocolGroupTreeNode);

						lastProtocolGroupTreeNode = protocolGroupTreeNode;

						tsslStatus.Text = String.Format("Loading Protocol Group {0}", protocolGroup.name);
					}
					else if (doWorkEventArgs.UserState is ProtocolInfo.ProtocolGroup.Protocol)
					{
						ProtocolInfo.ProtocolGroup.Protocol protocol = ((ProtocolInfo.ProtocolGroup.Protocol)doWorkEventArgs.UserState);

						TreeNode protocolTreeNode = new TreeNode(String.Format("{0} ({1})", protocol.name, protocol.value));

						protocolTreeNode.Tag = protocol;

						if (protocol.detailsNotFound)
						{
							if (protocol.detailsOccurencesFound > 0)
							{
								protocolTreeNode.BackColor = Color.Orange;
							}
							else
							{
								protocolTreeNode.BackColor = Color.Red;
							}
						}

						if (lastProtocolGroupTreeNode != null)
						{
							lastProtocolGroupTreeNode.Nodes.Add(protocolTreeNode);
							lastProtocolGroupTreeNode.BackColor = Color.Empty;
						}

						tsslStatus.Text = String.Format("Loading Protocol {0}", protocol.name);
					}

					tspbStatus.ProgressBar.Value = doWorkEventArgs.ProgressPercentage;
				}
			};

			backgroundWorker.RunWorkerAsync();
		}
	}
}