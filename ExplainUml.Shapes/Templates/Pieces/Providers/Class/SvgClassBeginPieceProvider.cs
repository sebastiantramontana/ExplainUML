namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassBeginPieceProvider : PieceProviderBase, ISvgClassBeginPieceProvider
    {
        public SvgClassBeginPieceProvider()
            : base(Path.Combine(SvgClassPiecesPath.Path, "SvgClassBegin.piece"))
        {
        }
    }
}
