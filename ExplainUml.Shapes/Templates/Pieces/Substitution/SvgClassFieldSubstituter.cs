namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgClassFieldSubstituter : SvgBlockSubstituterBase, ISvgClassFieldSubstituter
    {
        private const string FieldTextTemplate = "{{FieldText}}";
        private const string FieldPositionYTemplate = "{{FieldPositionY}}";
        private const string FieldPaddingTopTemplate = "{{FieldPaddingTop}}";

        public SvgClassFieldSubstituter()
            : base(FieldTextTemplate, FieldPositionYTemplate, FieldPaddingTopTemplate)
        {
        }
    }
}
