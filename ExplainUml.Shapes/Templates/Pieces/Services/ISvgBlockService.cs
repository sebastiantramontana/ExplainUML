namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgBlockService
    {
        string GetBlocksContent(IEnumerable<string> blockTexts, int initialFieldPositionY, int initialFieldPaddingTop, string pieceContent);
    }
}