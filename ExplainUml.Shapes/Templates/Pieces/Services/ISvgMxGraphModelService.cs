namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgMxGraphModelService
    {
        Task<string> GetContent(string svgContent);
    }
}
