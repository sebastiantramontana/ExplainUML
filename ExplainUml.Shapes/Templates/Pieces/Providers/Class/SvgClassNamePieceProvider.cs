namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassNamePieceProvider : PieceProviderBase, ISvgClassNamePieceProvider
    {
        public SvgClassNamePieceProvider()
            : base(Path.Combine(SvgClassPiecesPath.Path, "SvgClassName.piece"))
        {
        }
    }
}
