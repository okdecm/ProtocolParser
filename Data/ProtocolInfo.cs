using System.Collections.Generic;
using System.IO;
using ProtocolParser.Extensions;

namespace ProtocolParser.Data
{
    internal class ProtocolInfo : ISerializable
    {
        private const ushort CurrentInfoVersion = 0;
        private const byte MaximumProtocols = 2 ^ 6;

        public ushort InfoVersion { get; private set; } = CurrentInfoVersion;
        public List<ProtocolGroup> Groups { get; set; }

        public ProtocolInfo()
        {
            Groups = new List<ProtocolGroup>(MaximumProtocols);
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(InfoVersion);

            writer.Write((byte)Groups.Count);
            foreach (var protocolGroup in Groups)
            {
                writer.Write(protocolGroup);
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            InfoVersion = reader.ReadUInt16();

            var count = reader.ReadByte();
            for (var i = 0; i < count; i++)
            {
                Groups.Add(reader.Read<ProtocolGroup>());
            }
        }
    }
}
