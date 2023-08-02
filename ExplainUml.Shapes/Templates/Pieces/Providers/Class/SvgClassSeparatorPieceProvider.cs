namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassSeparatorPieceProvider : PieceProviderBase, ISvgClassSeparatorPieceProvider
    {
        private const string PIECE_FILE = "SvgClassSeparator.piece";

        public SvgClassSeparatorPieceProvider(IPieceReader pieceReader, ISvgClassPiecesPath svgClassPiecesPath)
            : base(pieceReader, svgClassPiecesPath.GetFilePath(PIECE_FILE))
        {
        }
    }
}
