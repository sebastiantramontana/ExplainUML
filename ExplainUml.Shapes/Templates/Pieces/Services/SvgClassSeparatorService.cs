using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassSeparatorService : ISvgClassSeparatorService
    {
        private readonly ISvgClassSeparatorPieceProvider _svgClassSeparatorPieceProvider;
        private readonly SvgClassSeparatorSubstituter _svgClassSeparatorSubstituter;

        public SvgClassSeparatorService(ISvgClassSeparatorPieceProvider svgClassSeparatorPieceProvider, SvgClassSeparatorSubstituter svgClassSeparatorSubstituter)
        {
            _svgClassSeparatorPieceProvider = svgClassSeparatorPieceProvider;
            _svgClassSeparatorSubstituter = svgClassSeparatorSubstituter;
        }

        public async Task<string> GetSeparatorContent(int positionY)
        {
            var pieceContent = await _svgClassSeparatorPieceProvider.GetPieceContent();
            return _svgClassSeparatorSubstituter.Substitute(positionY, pieceContent);
        }
    }
}
