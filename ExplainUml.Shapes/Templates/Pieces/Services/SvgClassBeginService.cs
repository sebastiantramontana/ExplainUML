using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassBeginService : ISvgClassBeginService
    {
        private readonly ISvgClassBeginPieceProvider _svgClassBeginProvider;
        private readonly ISvgClassBeginSubstituter _svgClassBeginSubstituter;

        public SvgClassBeginService(ISvgClassBeginPieceProvider svgClassBeginProvider, ISvgClassBeginSubstituter svgClassBeginSubstituter)
        {
            _svgClassBeginProvider = svgClassBeginProvider;
            _svgClassBeginSubstituter = svgClassBeginSubstituter;
        }

        public async Task<string> GetBeginContent(int classHeight)
        {
            var pieceContent = await _svgClassBeginProvider.GetPieceContent();
            return _svgClassBeginSubstituter.Substitute(classHeight, pieceContent);
        }
    }
}
