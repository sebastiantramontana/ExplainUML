namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassFieldPieceProvider : PieceProviderBase, ISvgClassFieldPieceProvider
    {
        public SvgClassFieldPieceProvider()
            : base(Path.Combine(SvgClassPiecesPath.Path, "SvgClassField.piece"))
        {
        }
    }
}
