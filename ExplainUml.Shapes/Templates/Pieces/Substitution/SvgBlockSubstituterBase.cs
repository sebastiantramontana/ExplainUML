using ExplainUml.Shapes.Templates.Trasncluders.Formatters;

namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal abstract class SvgBlockSubstituterBase : ISvgBlockSubstituter
    {
        private readonly string _blockTextTemplate;
        private readonly string _blockPositionYTemplate;
        private readonly string _blockPaddingTopTemplate;

        protected SvgBlockSubstituterBase(string blockTextTemplate, string blockPositionYTemplate, string blockPaddingTopTemplate)
        {
            _blockTextTemplate = blockTextTemplate;
            _blockPositionYTemplate = blockPositionYTemplate;
            _blockPaddingTopTemplate = blockPaddingTopTemplate;
        }

        public string Substitute(string blockText, int fieldPositionY, int fieldPaddingTop, string fieldBlockContentTemplate)
        {
            return fieldBlockContentTemplate
                .Replace(_blockTextTemplate, blockText, StringComparison.InvariantCulture)
                .Replace(_blockPositionYTemplate, fieldPositionY.ToString(), StringComparison.InvariantCulture)
                .Replace(_blockPaddingTopTemplate, fieldPaddingTop.ToString(), StringComparison.InvariantCulture);
        }
    }
}
