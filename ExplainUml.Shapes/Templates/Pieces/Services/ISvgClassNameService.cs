namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassNameService
    {
        Task<string> GetClassNameContent(string className, int initialPositionY, int initialPaddingTop);
    }
}