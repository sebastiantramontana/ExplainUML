using ExplainUml.BuildingBlocks;
using ExplainUml.BuildingBlocks.Properties;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal interface ISvgFieldsTranscluder
    {
        string Transclude(IEnumerable<Property> properties, IEnumerable<Event> events, string templateContent);
    }
}
