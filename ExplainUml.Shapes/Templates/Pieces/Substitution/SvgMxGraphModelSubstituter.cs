namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgMxGraphModelSubstituter : ISvgMxGraphModelSubstituter
    {
        private const string Base64DeflatedSvgContentTemplate = "{{Base64DeflatedSvgContent}}";

        public string Substitute(string mxGraphModelText, string base64DeflatedSvgContent)
            => mxGraphModelText.Replace(Base64DeflatedSvgContentTemplate, base64DeflatedSvgContent, StringComparison.InvariantCulture);
    }
}
