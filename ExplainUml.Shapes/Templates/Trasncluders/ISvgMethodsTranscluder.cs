using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal interface ISvgMethodsTranscluder
    {
        string Tranclude(IEnumerable<Method> methods, string templateContent);
    }
}
