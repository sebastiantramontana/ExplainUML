using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassDrawingPieceService : ISvgClassDrawingPieceService
    {
        private readonly ISvgClassDrawingPieceProvider _svgClassDrawingPieceProvider;
        private readonly ISvgClassDrawingSubstituter _svgClassDrawingSubstituter;

        public SvgClassDrawingPieceService(ISvgClassDrawingPieceProvider svgClassDrawingPieceProvider, ISvgClassDrawingSubstituter svgClassDrawingSubstituter)
        {
            _svgClassDrawingPieceProvider = svgClassDrawingPieceProvider;
            _svgClassDrawingSubstituter = svgClassDrawingSubstituter;
        }

        public async Task<string> GetDrawingContent(int classHeight, int blockHeight)
        {
            var pieceContent = await _svgClassDrawingPieceProvider.GetPieceContent();
            return _svgClassDrawingSubstituter.Substitute(blockHeight, classHeight, pieceContent);
        }
    }
}
