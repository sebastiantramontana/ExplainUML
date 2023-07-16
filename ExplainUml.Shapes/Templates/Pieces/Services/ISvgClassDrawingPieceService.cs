using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassDrawingPieceService
    {
        Task<string> GetDrawingContent(Class @class);
    }
}