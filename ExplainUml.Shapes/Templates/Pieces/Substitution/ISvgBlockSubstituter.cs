namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal interface ISvgBlockSubstituter
    {
        string Substitute(string blockText, int fieldPositionY, int fieldPaddingTop, string fieldBlockContentTemplate);
    }
}