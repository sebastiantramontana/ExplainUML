namespace ExplainUml.Shapes.Templates.Pieces.Providers.Class
{
    internal class SvgClassNamePieceProvider : PieceProviderBase, ISvgClassNamePieceProvider
    {
        private const string PIECE_FILE = "SvgClassName.piece";

        public SvgClassNamePieceProvider(IPieceReader pieceReader)
            : base(pieceReader, SvgClassPiecesPath.Path + "." + PIECE_FILE)
        {
        }
    }
}
