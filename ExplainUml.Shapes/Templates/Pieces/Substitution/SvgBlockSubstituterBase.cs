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
                .Replace(_blockTextTemplate, blockText)
                .Replace(_blockPositionYTemplate, fieldPositionY.ToString())
                .Replace(_blockPaddingTopTemplate, fieldPaddingTop.ToString());
        }
    }
}
