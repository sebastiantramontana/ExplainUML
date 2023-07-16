using System.Reflection;
using System.Text;

namespace ExplainUml.Shapes.Templates.Pieces.Providers
{
    internal abstract class PieceProviderBase : IPieceProvider
    {
        private readonly string _fileName;

        protected PieceProviderBase(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<string> GetPieceContent()
        {
            var file = Assembly.GetAssembly(typeof(PieceProviderBase))!.GetManifestResourceStream(_fileName) ?? throw new FileNotFoundException(FileName);
            var bytes = new byte[file!.Length];

            await file.ReadAsync(bytes);

            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
