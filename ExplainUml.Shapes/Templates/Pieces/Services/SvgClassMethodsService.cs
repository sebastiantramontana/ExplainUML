using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;
using ExplainUml.Shapes.Templates.Trasncluders.Formatters;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassMethodsService : SvgBlockServiceBase, ISvgClassMethodsService
    {
        private readonly ISvgClassMethodPieceProvider _svgClassMethodPieceProvider;
        private readonly IMethodFormatter _methodFormatter;

        public SvgClassMethodsService(ISvgClassMethodPieceProvider svgClassMethodPieceProvider, ISvgClassMethodSubstituter svgClassMethodSubstituter, IMethodFormatter methodFormatter)
            : base(svgClassMethodSubstituter)
        {
            _svgClassMethodPieceProvider = svgClassMethodPieceProvider;
            _methodFormatter = methodFormatter;
        }

        public async Task<string> GetMethodsContent(IEnumerable<Method> methods, int initialPositionY, int initialPaddingTop)
        {
            var pieceContent = await _svgClassMethodPieceProvider.GetPieceContent();

            var formattedMethods = FormatMethods(methods);
            return GetBlocksContent(formattedMethods, initialPositionY, initialPaddingTop, pieceContent));
        }

        private IEnumerable<string> FormatMethods(IEnumerable<Method> methods)
            => methods.Select(e => _methodFormatter.Format(e));
    }
}
