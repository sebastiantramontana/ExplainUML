namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassMethodPieceProvider : PieceProviderBase, ISvgClassMethodPieceProvider
    {
        public SvgClassMethodPieceProvider()
            : base(Path.Combine(SvgClassPiecesPath.Path, "SvgClassMethod.piece"))
        {
        }
    }
}
