using System.IO.Compression;
using System.Text;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class Deflater : IDeflater
    {
        public async Task<byte[]> Deflate(string content)
        {
            await using var outputStream = new MemoryStream();
            await using (var deflateStream = new ZLibStream(outputStream, CompressionMode.Compress))
            await using (var writer = new StreamWriter(deflateStream))
                await writer.WriteAsync(content);

            return outputStream.ToArray();
        }
    }
}
