using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Trasncluders;
using System.Text;

namespace ExplainUml.Shapes.Services
{
    internal class ClassSvgShapeService : ISvgShapeService<Class>
    {
        private const string MimeHeader = "data:image/svg+xml;base64,";
        private readonly ISvgClassTrasncluder _svgClassTrasncluder;

        public ClassSvgShapeService(ISvgClassTrasncluder svgClassTrasncluder)
        {
            _svgClassTrasncluder = svgClassTrasncluder;
        }

        public async Task<string> GetBase64Image(Class @class)
        {
            var classTrancluded = await _svgClassTrasncluder.Transclude(@class);
            return MimeHeader + Convert.ToBase64String(Encoding.UTF8.GetBytes(classTrancluded));
        }
    }
}
