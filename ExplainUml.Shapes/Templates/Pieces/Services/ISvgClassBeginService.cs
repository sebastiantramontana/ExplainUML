namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface ISvgClassBeginService
    {
        Task<string> GetPreliminaryContent(int classHeight);
        Task<string> AddContentAttribute(string svgClassContent);
    }
}