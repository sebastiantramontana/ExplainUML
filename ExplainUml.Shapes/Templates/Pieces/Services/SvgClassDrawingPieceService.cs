using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;
using System.Security.Claims;

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

        public async Task<string> GetDrawingContent(Class @class)
        {
            var pieceContent = await _svgClassDrawingPieceProvider.GetPieceContent();

            var blockCount = CountBlocks(@class);
            var classHeight = CalculateClassHeight(blockCount);

            return _svgClassDrawingSubstituter.Substitute(SvgClassInfo.BlockHeight, classHeight, pieceContent);
        }
        private int CountBlocks(Class @class)
            => @class.Events.Count() + @class.Properties.Count() + @class.Methods.Count() + 1;

        private int CalculateClassHeight(int blockCount)
            => SvgClassInfo.BlockHeight * blockCount + SvgClassInfo.DivisionSeparatorHeight;
    }
}
