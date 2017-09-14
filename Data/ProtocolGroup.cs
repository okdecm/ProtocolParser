using System.Collections.Generic;
using System.IO;
using ProtocolParser.Extensions;

namespace ProtocolParser.Data
{
    internal class ProtocolGroup : ISerializable
    {
        private const ushort MaximumProtocols = 2 ^ 10;

        public string Name { get; set; }
        public byte Id { get; set; }
        public List<Protocol> Protocols { get; set; }

        public ProtocolGroup()
        {
            Protocols = new List<Protocol>(MaximumProtocols);
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Name.Trim());
            writer.Write(Id);

            writer.Write((ushort)Protocols.Count);
            foreach (var protocol in Protocols)
            {
                writer.Write(protocol);
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            Name = reader.ReadString();
            Id = reader.ReadByte();

            var protocolCount = reader.ReadUInt16();
            for (var i = 0; i < protocolCount; i++)
            {
                Protocols.Add(reader.Read<Protocol>());
            }
        }
    }
}