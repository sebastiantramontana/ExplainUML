namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassDrawingPiecetProvider : PieceProviderBase, ISvgClassDrawingPieceProvider
    {
        public SvgClassDrawingPiecetProvider()
            : base(Path.Combine(SvgClassPiecesPath.Path, "SvgClassDrawing.piece"))
        {
        }
    }
}
