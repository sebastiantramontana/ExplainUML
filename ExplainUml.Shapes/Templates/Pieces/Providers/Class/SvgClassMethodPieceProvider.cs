namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassMethodPieceProvider : PieceProviderBase, ISvgClassMethodPieceProvider
    {
        private const string PIECE_FILE = "SvgClassMethod.piece";

        public SvgClassMethodPieceProvider(IPieceReader pieceReader, ISvgClassPiecesPath svgClassPiecesPath)
            : base(pieceReader, svgClassPiecesPath.GetFilePath(PIECE_FILE))
        {
        }
    }
}
