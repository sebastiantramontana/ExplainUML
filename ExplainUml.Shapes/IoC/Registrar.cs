using ExplainUml.BuildingBlocks;
using ExplainUml.Infrastructure;
using ExplainUml.Shapes.Services;
using ExplainUml.Shapes.Templates.Pieces.Providers;
using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Services;
using ExplainUml.Shapes.Templates.Pieces.Substitution;
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
                .RegisterSingleton<ISvgClassBeginPieceProvider, SvgClassBeginPieceProvider>()
                .RegisterSingleton<ISvgClassDrawingPieceProvider, SvgClassDrawingPieceProvider>()
                .RegisterSingleton<ISvgClassEndPieceProvider, SvgClassEndPieceProvider>()
                .RegisterSingleton<ISvgClassFieldPieceProvider, SvgClassFieldPieceProvider>()
                .RegisterSingleton<ISvgClassMethodPieceProvider, SvgClassMethodPieceProvider>()
                .RegisterSingleton<ISvgClassNamePieceProvider, SvgClassNamePieceProvider>()
                .RegisterSingleton<ISvgClassSeparatorPieceProvider, SvgClassSeparatorPieceProvider>()
                .RegisterSingleton<IPieceReader, PieceReaderFromAssembly>()
                .RegisterSingleton<ISvgClassBeginService, SvgClassBeginService>()
                .RegisterSingleton<ISvgClassDrawingPieceService, SvgClassDrawingPieceService>()
                .RegisterSingleton<ISvgClassEndService, SvgClassEndService>()
                .RegisterSingleton<ISvgClassFieldsService, SvgClassFieldsService>()
                .RegisterSingleton<ISvgClassMethodsService, SvgClassMethodsService>()
                .RegisterSingleton<ISvgClassNameService, SvgClassNameService>()
                .RegisterSingleton<ISvgClassSeparatorService, SvgClassSeparatorService>()
                .RegisterSingleton<ISvgClassBeginSubstituter, SvgClassBeginSubstituter>()
                .RegisterSingleton<ISvgClassDrawingSubstituter, SvgClassDrawingSubstituter>()
                .RegisterSingleton<ISvgClassFieldSubstituter, SvgClassFieldSubstituter>()
                .RegisterSingleton<ISvgClassMethodSubstituter, SvgClassMethodSubstituter>()
                .RegisterSingleton<ISvgClassNameSubstituter, SvgClassNameSubstituter>()
                .RegisterSingleton<ISvgClassSeparatorSubstituter, SvgClassSeparatorSubstituter>()
                .RegisterSingleton<ISvgShapeService<Class>, ClassSvgShapeService>()
                .RegisterSingleton<ISvgClassTrasncluder, SvgClassTrasncluder>()
                .RegisterSingleton<IAccesibilityStereotyper, UmlAccesibilityStereotyper>()
                .RegisterSingleton<IOverridingStereotyper, OverridingStereotyper>()
                .RegisterSingleton<IEventFormatter, EventFormatter>()
                .RegisterSingleton<IMethodFormatter, MethodFormatter>()
                .RegisterSingleton<IPropertyFormatter, PropertyFormatter>()
                .RegisterSingleton<ISymbolFormatter, SymbolFormatter>();
        }
    }
}
