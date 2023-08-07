using ExplainUml.Shapes.Templates.Pieces.Providers.MxGraphModel;
using ExplainUml.Shapes.Templates.Pieces.Substitution;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgMxGraphModelService : ISvgMxGraphModelService
    {
        private readonly ISvgMxGraphModelPieceProvider _provider;
        private readonly ISvgMxGraphModelSubstituter _substituter;
        private readonly IDeflater _deflater;

        public SvgMxGraphModelService(ISvgMxGraphModelPieceProvider provider, ISvgMxGraphModelSubstituter substituter, IDeflater deflater)
        {
            _provider = provider;
            _substituter = substituter;
            _deflater = deflater;
        }

        public async Task<string> GetContent(string svgContent)
        {
            var pieceContent = await _provider.GetPieceContent();
            var deflatedSvgContent = await _deflater.Deflate(svgContent);
            var base64DeflatedSvgContent = Convert.ToBase64String(deflatedSvgContent);

            return _substituter.Substitute(pieceContent, base64DeflatedSvgContent);
        }
    }
}
