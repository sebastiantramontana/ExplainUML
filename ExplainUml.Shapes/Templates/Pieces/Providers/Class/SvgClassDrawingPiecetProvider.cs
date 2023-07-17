namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassDrawingPiecetProvider : PieceProviderBase, ISvgClassDrawingPieceProvider
    {
        private const string PIECE_FILE = "SvgClassDrawing.piece";

        public SvgClassDrawingPiecetProvider(IPieceReader pieceReader)
            : base(pieceReader, Path.Combine(SvgClassPiecesPath.Path, PIECE_FILE))
        {
        }
    }
}
