using ExplainUml.Shapes.Templates.Pieces.Providers.Class;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassBeginService : ISvgClassBeginService
    {
        private readonly ISvgClassBeginPieceProvider _svgClassBeginProvider;

        public SvgClassBeginService(ISvgClassBeginPieceProvider svgClassBeginProvider)
        {
            _svgClassBeginProvider = svgClassBeginProvider;
        }

        public Task<string> GetBeginContent() => _svgClassBeginProvider.GetPieceContent();
    }
}
