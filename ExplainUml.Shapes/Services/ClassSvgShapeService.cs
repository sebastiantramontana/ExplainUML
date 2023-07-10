using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Providers;
using ExplainUml.Shapes.Templates.Trasncluders;
using System.Text;

namespace ExplainUml.Shapes.Services
{
    internal class ClassSvgShapeService : ISvgShapeService<Class>
    {
        private const string MimeHeader = "data:image/svg+xml;base64,";

        private readonly ISvgClassTemplateProvider _svgClassResourceProvider;
        private readonly ISvgClassTrasncluder _svgClassTrasncluder;

        public ClassSvgShapeService(ISvgClassTemplateProvider svgClassResourceProvider, ISvgClassTrasncluder svgClassTrasncluder)
        {
            _svgClassResourceProvider = svgClassResourceProvider;
            _svgClassTrasncluder = svgClassTrasncluder;
        }

        public async Task<string> GetBase64Image(Class @class)
        {
            var templateContent = await _svgClassResourceProvider.GetTemplateContent();
            var classTrancluded = _svgClassTrasncluder.Transclude(@class, templateContent);

            return MimeHeader + Convert.ToBase64String(Encoding.UTF8.GetBytes(classTrancluded));
        }
    }
}
