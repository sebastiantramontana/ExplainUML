using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassMethodsService
    {
        Task<string> GetMethodsContent(IEnumerable<Method> methods, int initialPositionY, int initialPaddingTop);
    }
}