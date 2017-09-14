using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ProtocolParser.Data;

namespace ProtocolParser.Factory
{
    internal static class ProtocolFactory
    {
        public static void ParseFromHeader(ProtocolGroup group, string content, BackgroundWorker backgroundWorker)
        {
            var enumName = group.Name.Replace("NC_", "");

            var protocolsRegex = new Regex(string.Format(FactoryConstants.EnumRegexStringPattern,
                $"PROTOCOL_COMMAND_{enumName}"));

            var protocolsRegexMatch = protocolsRegex.Match(content);
            if (protocolsRegexMatch.Groups.Count <= 1)
                return;

            var values = protocolsRegexMatch.Groups[1].ToString()
                .Split(new[] {"\r\n"}, StringSplitOptions.None)
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Trim(' ', '\0', '\n', ','))
                .ToArray();

            foreach (var value in values)
            {
                var protocol = CreateProtocol(value, content);
                if (protocol == null)
                    continue;

                group.Protocols.Add(protocol);
                backgroundWorker?.ReportProgress(group.Protocols.Count / values.Length * 100, protocol);
            }
        }

        private static Protocol CreateProtocol(string value, string content)
        {
            var groupNameByValue = value
                .Split(new[] {" = "}, StringSplitOptions.None)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();

            if (groupNameByValue.Length <= 1)
                return null;

            var protocolId = ushort.Parse(groupNameByValue[1].Replace("0x", ""), NumberStyles.HexNumber);
            var protocolName = groupNameByValue[0];

            Debug.WriteLine($"Parsed {protocolName} - {protocolId}");

            var result = new Protocol
            {
                Id = protocolId,
                Name = protocolName,
                Structure = string.Empty
            };

            var detailsRegex = new Regex(string.Format(FactoryConstants.StructRegexStringPattern, $"PROTO_{result.Name}"));
            var detailsRegexMatches = detailsRegex.Matches(content);
            if (detailsRegexMatches.Count <= 0)
                return result;

            var builder = new StringBuilder();

            builder.Append(detailsRegexMatches[0].Value);

            for (var index = 1; index < detailsRegexMatches.Count; index++)
            {
                builder.Append(Environment.NewLine);
                builder.Append(Environment.NewLine);
                builder.Append(detailsRegexMatches[index].Value);
            }

            result.Structure = builder.ToString();

            return result;
        }
    }
}