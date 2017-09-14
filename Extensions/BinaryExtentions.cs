using System.IO;
using System.IO.Compression;
using System.Text;
using ProtocolParser.Data;

namespace ProtocolParser.Extensions
{
    internal static class BinaryExtentions
    {
        internal static void Write<T>(this BinaryWriter writer, T serializableObject)
            where T : ISerializable
        {
            serializableObject.Serialize(writer);
        }

        internal static T Read<T>(this BinaryReader reader)
            where T : ISerializable, new()
        {
            var serializableObject = new T();
            serializableObject.Deserialize(reader);
            return serializableObject;
        }

        internal static void Compress(this BinaryWriter writer, string value)
        {
            using (var compressedStream = new MemoryStream())
            {
                using (var uncompressedStream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
                using (var compressorStream = new DeflateStream(compressedStream, CompressionMode.Compress))
                {
                    uncompressedStream.CopyTo(compressorStream);
                }

                var outputBuffer = compressedStream.ToArray();

                writer.Write((int) outputBuffer.Length);
                writer.Write(outputBuffer);
            }
        }

        internal static string Decompress(this BinaryReader reader)
        {
            var length = reader.ReadInt32();
            var inputBuffer = reader.ReadBytes(length);
            
            using (var uncompressedStream = new MemoryStream())
            {
                using (var compressedStream = new MemoryStream(inputBuffer))
                using (var compressorStream = new DeflateStream(compressedStream, CompressionMode.Decompress))
                {
                    compressorStream.CopyTo(uncompressedStream);
                }

                return Encoding.UTF8.GetString(uncompressedStream.ToArray());
            }
        }
    }
}