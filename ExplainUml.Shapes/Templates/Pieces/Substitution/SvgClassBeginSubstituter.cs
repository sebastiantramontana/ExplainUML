namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgClassBeginSubstituter : ISvgClassBeginSubstituter
    {
        private const string ClassHeightTemplate = "{{ClassHeight}}";

        public string Substitute(int classHeight, string classBeginContentTemplate)
            => classBeginContentTemplate.Replace(ClassHeightTemplate, classHeight.ToString(), StringComparison.InvariantCulture);
    }
}
