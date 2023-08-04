using System.IO.Compression;
using System.Text;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class Deflater : IDeflater
    {
        public byte[] Deflate(string content)
        {
            var streamContent = new MemoryStream(Encoding.UTF8.GetBytes(content));
            var zlib = new ZLibStream(streamContent, CompressionMode.Compress);

            var bytes = new Span<byte>();
            zlib.Read(bytes);

            return bytes.ToArray();
        }
    }
}
