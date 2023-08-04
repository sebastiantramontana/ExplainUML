namespace ExplainUml.Shapes.Templates.Pieces.Providers.MxGraphModel
{
    internal class SvgMxGraphModelPieceProvider : PieceProviderBase, ISvgMxGraphModelPieceProvider
    {
        private const string PIECE_FILE = "SvgMxGraphModel.piece";

        public SvgMxGraphModelPieceProvider(IPieceReader pieceReader, ISvgMxGraphModelPiecesPath svgMxGraphModelPiecesPath)
            : base(pieceReader, svgMxGraphModelPiecesPath.GetFilePath(PIECE_FILE))
        {
        }
    }
}
