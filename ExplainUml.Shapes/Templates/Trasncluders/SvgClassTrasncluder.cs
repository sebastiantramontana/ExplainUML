using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal class SvgClassTrasncluder : ISvgClassTrasncluder
    {
        private const string ClassNameSubstitution = "{{classname}}";

        private readonly ISvgFieldsTranscluder _svgFieldsTranscluder;
        private readonly ISvgMethodsTranscluder _svgMethodsTranscluder;

        public SvgClassTrasncluder(ISvgFieldsTranscluder svgFieldsTranscluder, ISvgMethodsTranscluder svgMethodsTranscluder)
        {
            _svgFieldsTranscluder = svgFieldsTranscluder;
            _svgMethodsTranscluder = svgMethodsTranscluder;
        }

        public string Transclude(Class @class, string templateContent)
        {
            var newContent = ReplaceClassName(@class, templateContent);
            newContent = _svgFieldsTranscluder.Transclude(@class.Properties, @class.Events, newContent);
            return _svgMethodsTranscluder.Tranclude(@class.Methods, newContent);
        }

        private string ReplaceClassName(Class @class, string templateContent)
            => templateContent.Replace(ClassNameSubstitution, @class.Name, StringComparison.InvariantCulture);
    }
}
