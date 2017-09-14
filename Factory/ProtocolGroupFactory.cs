using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProtocolParser.Data;

namespace ProtocolParser.Factory
{
    internal static class ProtocolGroupFactory
    {
        private static readonly Regex ProtocolGroupRegex = new Regex(string.Format(FactoryConstants.EnumRegexStringPattern, "PROTOCOL_COMMAND"));

        private static readonly Dictionary<string, string> GroupNamesAliases = new Dictionary<string, string>
        {
            { "NC_KQ", "NC_KINGDOMQUEST" },
            { "NC_WT", "NC_WEAPONTITLE" },
            { "NC_CT", "NC_CHARACTERTITLE" },
            { "NC_HOLY_PROMISE", "NC_HOLYPROMISE" },
            { "NC_MID", "NC_MATCH_INSTANCE_DUNGEON" }
        };

        public static List<ProtocolGroup> CreateFromHeader(string content, BackgroundWorker backgroundWorker)
        {
            backgroundWorker?.ReportProgress(0, null);

            var groups = new List<ProtocolGroup>();

            // Parse All protocol groups.
            var protocolGroupsRegexMatch = ProtocolGroupRegex.Match(content);
            if (protocolGroupsRegexMatch.Groups.Count > 1)
            {
                var values = protocolGroupsRegexMatch.Groups[1].ToString()
                    .Split(new[] { "\r\n" }, StringSplitOptions.None)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

                var loadedGroupCount = 0;

                foreach (var value in values)
                {
                    var groupNameByValue = value.Trim(' ', ',', '\0', '\n')
                        .Split(new[] { " = " }, StringSplitOptions.None);

                    if (groupNameByValue.Length > 1)
                    {
                        var groupId = byte.Parse(groupNameByValue[1].Replace("0x", ""), NumberStyles.HexNumber);
                        var groupName = groupNameByValue[0];

                        Debug.WriteLine($"Parsed: {groupName} - {groupId}");

                        if (GroupNamesAliases.TryGetValue(groupName, out var alias))
                        {
                            groupName = alias; // Set alias if found.
                        }

                        var protocolGroup = new ProtocolGroup
                        {
                            Id = groupId,
                            Name = groupName,
                        };

                        backgroundWorker?.ReportProgress(loadedGroupCount / values.Length * 100, protocolGroup);
                        
                        groups.Add(protocolGroup);
                    }

                    loadedGroupCount++;
                }
            }

            // Run this multi-threaded. - Cheap implementation.
            var tasks = new List<Task>();
            foreach (var group in groups)
            {
               var task = Task.Run(() => ProtocolFactory.ParseFromHeader(group, content, backgroundWorker));
               tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            backgroundWorker?.ReportProgress(100, null);

            return groups;
        }
    }
}
