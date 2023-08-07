namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal interface ISvgClassBeginSubstituter
    {
        string SubstituteHeight(int classHeight, string classBeginContentTemplate);
        string SubstituteMxGraphModel(string base64MxGraphModelContent);
    }
}