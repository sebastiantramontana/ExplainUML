namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassDrawingPieceProvider : PieceProviderBase, ISvgClassDrawingPieceProvider
    {
        private const string PIECE_FILE = "SvgClassDrawing.piece";

        public SvgClassDrawingPieceProvider(IPieceReader pieceReader, ISvgClassPiecesPath svgClassPiecesPath)
            : base(pieceReader, svgClassPiecesPath.GetFilePath(PIECE_FILE))
        {
        }
    }
}
