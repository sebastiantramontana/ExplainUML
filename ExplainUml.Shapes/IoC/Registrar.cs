using ExplainUml.BuildingBlocks;
using ExplainUml.Infrastructure;
using ExplainUml.Shapes.Services;
using ExplainUml.Shapes.Templates.Providers;
using ExplainUml.Shapes.Templates.Trasncluders;
using ExplainUml.Shapes.Templates.Trasncluders.Formatters;
using ExplainUml.Shapes.Templates.Trasncluders.Stereotypes;

namespace ExplainUml.Shapes.IoC
{
    public static class Registrar
    {
        public static IRegistrar RegisterServices(IRegistrar registrar)
        {
            return registrar
                 .RegisterSingleton<ISvgShapeService<Class>, ClassSvgShapeService>()
                 .RegisterSingleton<ISvgClassTemplateProvider, SvgClassTemplateProvider>()
                 .RegisterSingleton<ISvgClassTrasncluder, SvgClassTrasncluder>()
                 .RegisterSingleton<ISvgFieldsTranscluder, SvgFieldsTranscluder>()
                 .RegisterSingleton<ISvgMethodsTranscluder, SvgMethodsTranscluder>()
                 .RegisterSingleton<IAccesibilityStereotyper, UmlAccesibilityStereotyper>()
                 .RegisterSingleton<IOverridingStereotyper, OverridingStereotyper>()
                 .RegisterSingleton<IEventFormatter, EventFormatter>()
                 .RegisterSingleton<IMethodFormatter, MethodFormatter>()
                 .RegisterSingleton<IPropertyFormatter, PropertyFormatter>()
                 .RegisterSingleton<ISymbolFormatter, SymbolFormatter>();
        }
    }
}
