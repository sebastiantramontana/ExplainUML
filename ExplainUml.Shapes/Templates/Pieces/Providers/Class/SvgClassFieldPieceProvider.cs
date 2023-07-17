namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassFieldPieceProvider : PieceProviderBase, ISvgClassFieldPieceProvider
    {
        private const string PIECE_FILE = "SvgClassField.piece";

        public SvgClassFieldPieceProvider(IPieceReader pieceReader)
            : base(pieceReader, Path.Combine(SvgClassPiecesPath.Path, PIECE_FILE))
        {
        }
    }
}
