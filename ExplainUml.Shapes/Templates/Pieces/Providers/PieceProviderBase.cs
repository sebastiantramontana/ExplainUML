namespace ExplainUml.Shapes.Templates.Pieces.Providers
{
    internal abstract class PieceProviderBase : IPieceProvider
    {
        private readonly IPieceReader _pieceReader;
        private readonly string _fileName;

        protected PieceProviderBase(IPieceReader pieceReader, string fileName)
        {
            _pieceReader = pieceReader;
            _fileName = fileName;
        }

        public Task<string> GetPieceContent()
        {
            return _pieceReader.Read(_fileName);
        }
    }
}
