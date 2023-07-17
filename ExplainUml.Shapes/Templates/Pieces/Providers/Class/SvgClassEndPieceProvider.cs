namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassEndPieceProvider : PieceProviderBase, ISvgClassEndPieceProvider
    {
        private const string PIECE_FILE = "SvgClassEnd.piece";

        public SvgClassEndPieceProvider(IPieceReader pieceReader)
            : base(pieceReader, Path.Combine(SvgClassPiecesPath.Path, PIECE_FILE))
        {
        }
    }
}
