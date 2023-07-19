namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassDrawingPieceService
    {
        Task<string> GetDrawingContent(int classHeight, int blockHeight);
    }
}