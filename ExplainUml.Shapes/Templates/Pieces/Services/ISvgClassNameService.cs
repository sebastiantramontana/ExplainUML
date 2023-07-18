namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassNameService
    {
        Task<string> GetContent(string className, int initialPositionY, int initialPaddingTop);
    }
}