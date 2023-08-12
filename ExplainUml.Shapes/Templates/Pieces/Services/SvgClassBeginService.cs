using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;
using System.Text;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassBeginService : ISvgClassBeginService
    {
        private readonly ISvgClassBeginPieceProvider _svgClassBeginProvider;
        private readonly ISvgClassBeginSubstituter _svgClassBeginSubstituter;
        private readonly ISvgMxGraphModelService _svgMxGraphModelService;

        public SvgClassBeginService(ISvgClassBeginPieceProvider svgClassBeginProvider, ISvgClassBeginSubstituter svgClassBeginSubstituter, ISvgMxGraphModelService svgMxGraphModelService)
        {
            _svgClassBeginProvider = svgClassBeginProvider;
            _svgClassBeginSubstituter = svgClassBeginSubstituter;
            _svgMxGraphModelService = svgMxGraphModelService;
        }

        public async Task<string> GetPreliminaryContent(int classHeight)
        {
            var pieceContent = await _svgClassBeginProvider.GetPieceContent();
            return _svgClassBeginSubstituter.SubstituteHeight(classHeight, pieceContent);
        }

        public async Task<string> AddContentAttribute(string svgClassContent)
        {
            var mxGraphModelContent = await _svgMxGraphModelService.GetContent(svgClassContent);
            var base64MxGraphModelContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(mxGraphModelContent));

            return _svgClassBeginSubstituter.SubstituteMxGraphModel(svgClassContent, base64MxGraphModelContent);
        }
    }
}
