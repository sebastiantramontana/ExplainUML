namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgClassSeparatorSubstituter : ISvgClassSeparatorSubstituter
    {
        private const string SeparatorPositionYTemplate = "{{SeparatorPositionY}}";

        public string Substitute(int positionY, string separatorContentTemplate)
            => separatorContentTemplate.Replace(SeparatorPositionYTemplate, positionY.ToString());
    }
}
