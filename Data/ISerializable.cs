using System.IO;

namespace ProtocolParser.Data
{
    internal interface ISerializable
    {
        void Serialize(BinaryWriter writer);
        void Deserialize(BinaryReader reader);
    }
}
