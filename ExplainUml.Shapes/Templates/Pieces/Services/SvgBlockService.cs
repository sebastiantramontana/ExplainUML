using ExplainUml.Shapes.Templates.Pieces.Substitution;
using System.Text;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgBlockService : ISvgBlockService
    {
        private readonly ISvgBlockSubstituter _svgBlockSubstituter;

        public SvgBlockService(ISvgBlockSubstituter svgBlockSubstituter)
        {
            _svgBlockSubstituter = svgBlockSubstituter;
        }

        public string GetBlocksContent(IEnumerable<string> blockTexts, int initialFieldPositionY, int initialFieldPaddingTop, string pieceContent)
        {
            var fieldPositionY = initialFieldPositionY;
            var fieldPaddingTop = initialFieldPaddingTop;

            var stringBuilder = new StringBuilder();

            foreach (var blockText in blockTexts)
            {
                stringBuilder.AppendLine(_svgBlockSubstituter.Substitute(blockText, fieldPositionY, fieldPaddingTop, pieceContent));
                fieldPositionY += SvgClassInfo.BlockHeight;
                fieldPaddingTop += SvgClassInfo.BlockHeight;
            }

            return stringBuilder.ToString();
        }
    }
}
