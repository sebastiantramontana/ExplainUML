using ExplainUml.Shapes.Templates.Trasncluders.Formatters;

namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgBlockSubstituter : ISvgBlockSubstituter
    {
        private const string FieldTextTemplate = "{{FieldText}}";
        private const string FieldPositionYTemplate = "{{FieldPositionY}}";
        private const string FieldPaddingTopTemplate = "{{FieldPaddingTop}}";

        private readonly IEventFormatter _eventFormatter;
        private readonly IPropertyFormatter _propertyFormatter;

        public SvgBlockSubstituter(IEventFormatter eventFormatter, IPropertyFormatter propertyFormatter)
        {
            _eventFormatter = eventFormatter;
            _propertyFormatter = propertyFormatter;
        }

        public string Substitute(string blockText, int fieldPositionY, int fieldPaddingTop, string fieldBlockContentTemplate)
        {
            return fieldBlockContentTemplate
                .Replace(FieldTextTemplate, blockText)
                .Replace(FieldPositionYTemplate, fieldPositionY.ToString())
                .Replace(FieldPaddingTopTemplate, fieldPaddingTop.ToString());
        }
    }
}
