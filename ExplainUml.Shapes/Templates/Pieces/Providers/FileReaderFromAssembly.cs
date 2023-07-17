using System.Reflection;

namespace ExplainUml.Shapes.Templates.Pieces.Providers
{
    internal class PieceReaderFromAssembly : IPieceReader
    {
        public Task<string> Read(string fileName)
        {
            var stream = Assembly.GetAssembly(typeof(PieceReaderFromAssembly))
                ?.GetManifestResourceStream(fileName)
                ?? throw new FileNotFoundException(fileName);

            var reader = new StreamReader(stream);

            return reader.ReadToEndAsync();
        }
    }
}
