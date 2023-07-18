namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassSeparatorPieceProvider : PieceProviderBase, ISvgClassSeparatorPieceProvider
    {
        private const string PIECE_FILE = "SvgClassSeparator.piece";

        public SvgClassSeparatorPieceProvider(IPieceReader pieceReader)
            : base(pieceReader, Path.Combine(SvgClassPiecesPath.Path, PIECE_FILE))
        {
        }
    }
}
