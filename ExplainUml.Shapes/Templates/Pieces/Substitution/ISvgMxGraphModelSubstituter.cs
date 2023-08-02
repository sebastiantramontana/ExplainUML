namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal interface ISvgMxGraphModelSubstituter
    {
        string Substitute(string mxGraphModelText, string Base64DeflatedSvgContent);
    }
}
