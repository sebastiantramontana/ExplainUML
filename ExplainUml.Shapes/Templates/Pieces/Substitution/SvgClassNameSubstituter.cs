namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgClassNameSubstituter : SvgBlockSubstituterBase, ISvgClassNameSubstituter
    {
        private const string ClassNameTextTemplate = "{{ClassNameText}}";
        private const string ClassNamePositionYTemplate = "{{ClassNamePositionY}}";
        private const string ClassNamePaddingTopTemplate = "{{ClassNamePaddingTop}}";

        public SvgClassNameSubstituter()
            : base(ClassNameTextTemplate, ClassNamePositionYTemplate, ClassNamePaddingTopTemplate)
        {
        }
    }
}
