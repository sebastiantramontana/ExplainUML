namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgClassBeginSubstituter : ISvgClassBeginSubstituter
    {
        private const string ClassHeightTemplate = "{{ClassHeight}}";
        private const string ClassMxGraphModelTemplate = "{{MxGraphModel}}";

        public string SubstituteHeight(int classHeight, string classBeginContentTemplate)
            => classBeginContentTemplate.Replace(ClassHeightTemplate, classHeight.ToString(), StringComparison.InvariantCulture);

        public string SubstituteMxGraphModel(string svgClassContent, string base64MxGraphModelContent)
            => svgClassContent.Replace(ClassMxGraphModelTemplate, base64MxGraphModelContent, StringComparison.InvariantCulture);
    }
}
