using System.IO;
using ProtocolParser.Extensions;

namespace ProtocolParser.Data
{
    internal class Protocol : ISerializable
    {
        public ushort Id { get; set; }
        public string Name { get; set; }
        public string Structure { get; set; }

        public bool HasNoStructure => string.IsNullOrEmpty(Structure);

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Id);
            writer.Write(Name.Trim());
            writer.Compress(Structure.Trim());
        }

        public void Deserialize(BinaryReader reader)
        {
            Id = reader.ReadUInt16();
            Name = reader.ReadString();
            Structure = reader.Decompress();
        }
    }
}