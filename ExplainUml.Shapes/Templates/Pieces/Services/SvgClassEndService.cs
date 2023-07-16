using ExplainUml.Shapes.Templates.Pieces.Providers.Class;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassEndService : ISvgClassEndService
    {
        private readonly ISvgClassEndPieceProvider _svgClassEndProvider;

        public SvgClassEndService(ISvgClassEndPieceProvider svgClassEndProvider)
        {
            _svgClassEndProvider = svgClassEndProvider;
        }

        public Task<string> GetEndContent() => _svgClassEndProvider.GetPieceContent();
    }
}
