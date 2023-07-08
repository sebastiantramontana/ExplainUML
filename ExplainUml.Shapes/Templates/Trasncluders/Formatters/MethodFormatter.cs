using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Trasncluders.Stereotypes;

namespace ExplainUml.Shapes.Templates.Trasncluders.Formatters
{
    internal class MethodFormatter : IMethodFormatter
    {
        private readonly IAccesibilityStereotyper _accesibilityStereotyper;
        private readonly IOverridingStereotyper _overridingStereotyper;
        private readonly ISymbolFormatter _symbolFormatter;

        public MethodFormatter(IAccesibilityStereotyper accesibilityStereotyper,
            IOverridingStereotyper overridingStereotyper,
            ISymbolFormatter symbolFormatter)
        {
            _accesibilityStereotyper = accesibilityStereotyper;
            _overridingStereotyper = overridingStereotyper;
            _symbolFormatter = symbolFormatter;
        }

        public string Format(Method method)
            => _accesibilityStereotyper.GetStereotype(method.Accessibility)
            + _overridingStereotyper.GetStereotype(method.Overriding)
            + " "
            + method.Name
            + "(" + FormatParameters(method.Parameters) + ")"
            + ": " + method.ReturnType.Name;

        private string FormatParameters(IEnumerable<Symbol> parameters)
            => String.Join(",", parameters.Select(p => _symbolFormatter.Format(p)));
    }
}
