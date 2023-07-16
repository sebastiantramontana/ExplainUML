namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassEndPieceProvider : PieceProviderBase, ISvgClassEndPieceProvider
    {
        public SvgClassEndPieceProvider()
            : base(Path.Combine(SvgClassPiecesPath.Path, "SvgClassEnd.piece"))
        {
        }
    }
}
