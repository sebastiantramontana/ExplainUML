using ExplainUml.BuildingBlocks;
using ExplainUml.BuildingBlocks.Properties;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassFieldsService
    {
        Task<string> GetFieldsContent(IEnumerable<Event> events, IEnumerable<Property> properties, int initialPositionY, int initialPaddingTop);
    }
}