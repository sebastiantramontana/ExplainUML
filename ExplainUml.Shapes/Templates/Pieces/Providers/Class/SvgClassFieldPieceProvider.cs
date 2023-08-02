namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassFieldPieceProvider : PieceProviderBase, ISvgClassFieldPieceProvider
    {
        private const string PIECE_FILE = "SvgClassField.piece";

        public SvgClassFieldPieceProvider(IPieceReader pieceReader, ISvgClassPiecesPath svgClassPiecesPath)
            : base(pieceReader, svgClassPiecesPath.GetFilePath(PIECE_FILE))
        {
        }
    }
}
