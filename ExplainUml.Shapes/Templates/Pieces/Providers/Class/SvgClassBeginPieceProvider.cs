namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassBeginPieceProvider : PieceProviderBase, ISvgClassBeginPieceProvider
    {
        private const string PIECE_FILE = "SvgClassBegin.piece";

        public SvgClassBeginPieceProvider(IPieceReader pieceReader, ISvgClassPiecesPath svgClassPiecesPath)
            : base(pieceReader, svgClassPiecesPath.GetFilePath(PIECE_FILE))
        {
        }
    }
}
