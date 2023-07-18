using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassNameService : SvgBlockServiceBase
    {
        private readonly ISvgClassNamePieceProvider _svgClassNamePieceProvider;

        public SvgClassNameService(ISvgClassNamePieceProvider svgClassNamePieceProvider, ISvgBlockSubstituter svgBlockSubstituter)
            : base(svgBlockSubstituter)
        {
            _svgClassNamePieceProvider = svgClassNamePieceProvider;
        }

        public async Task<string> GetContent(string className, int initialPositionY, int initialPaddingTop)
        {
            var pieceContent = await _svgClassNamePieceProvider.GetPieceContent();
            return GetBlocksContent(new[] { className }, initialPositionY, initialPaddingTop, pieceContent));
        }
    }
}
