namespace ExplainUml.Shapes.Templates.Pieces.Providers.MxGraphModel
{
    internal class SvgMxGraphModelPiecesPath : SvgPiecesPathBase, ISvgMxGraphModelPiecesPath
    {
        private const string MxGraphModelFolder = ".MxGraphModel";

        public SvgMxGraphModelPiecesPath() : base(MxGraphModelFolder) { }
    }
}
