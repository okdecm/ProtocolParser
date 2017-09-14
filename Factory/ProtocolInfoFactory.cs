using System.ComponentModel;
using System.IO;
using System.Text;
using ProtocolParser.Data;
using ProtocolParser.Extensions;

namespace ProtocolParser.Factory
{
    internal static class ProtocolInfoFactory
    {
        public static ProtocolInfo ParseFromHeader(string headerFile, BackgroundWorker backgroundWorker)
        {
            var content = File.ReadAllText(headerFile);

            return new ProtocolInfo
            {
                Groups = ProtocolGroupFactory.CreateFromHeader(content, backgroundWorker)
            };
        }

        public static ProtocolInfo LoadFromProtocolParserBinary(string binaryFile)
        {
            ProtocolInfo protocolInfo;

            using (var fileStream = File.OpenRead(binaryFile))
            using (var reader = new BinaryReader(fileStream, Encoding.UTF8))
            {
                protocolInfo = reader.Read<ProtocolInfo>();
            }

            return protocolInfo;
        }
    }
}
