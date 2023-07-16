namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal interface ISvgClassDrawingSubstituter
    {
        string Substitute(int blockHeight, int classHeight, string classDrawingContentTemplate);
    }
}