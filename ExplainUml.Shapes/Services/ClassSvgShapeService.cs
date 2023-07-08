using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Providers;
using ExplainUml.Shapes.Templates.Trasncluders;

namespace ExplainUml.Shapes.Services
{
    internal class ClassSvgShapeService : ISvgShapeService<Class>
    {
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
            return _svgClassTrasncluder.Transclude(@class, templateContent);
        }
    }
}
