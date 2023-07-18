using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassMethodsService
    {
        Task<string> GetFieldsContent(IEnumerable<Method> methods, int initialPositionY, int initialPaddingTop);
    }
}