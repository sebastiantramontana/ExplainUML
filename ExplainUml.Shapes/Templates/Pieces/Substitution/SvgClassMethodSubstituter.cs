namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgClassMethodSubstituter : SvgBlockSubstituterBase, ISvgClassMethodSubstituter
    {
        private const string MethodTextTemplate = "{{MethodText}}";
        private const string MethodPositionYTemplate = "{{MethodPositionY}}";
        private const string MethodPaddingTopTemplate = "{{MethodPaddingTop}}";

        public SvgClassMethodSubstituter()
            : base(MethodTextTemplate, MethodPositionYTemplate, MethodPaddingTopTemplate)
        {
        }
    }
}
