using System.IO.Compression;
using System.Text;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class Deflater : IDeflater
    {
        public async Task<byte[]> Deflate(string content)
        {
            var inputBytes = Encoding.UTF8.GetBytes(content);

            await using var outputStream = new MemoryStream();
            await using var deflateStream = new ZLibStream(outputStream, CompressionMode.Compress, false);

            deflateStream.Write(inputBytes, 0, inputBytes.Length);

            return outputStream.ToArray();
        }
    }
}
