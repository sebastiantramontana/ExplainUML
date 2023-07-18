namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassSeparatorService
    {
        Task<string> GetSeparatorContent(int positionY);
    }
}