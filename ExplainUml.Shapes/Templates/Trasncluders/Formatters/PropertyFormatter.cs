using ExplainUml.BuildingBlocks.Properties;
using ExplainUml.Shapes.Templates.Trasncluders.Stereotypes;

namespace ExplainUml.Shapes.Templates.Trasncluders.Formatters
{
    internal class PropertyFormatter : IPropertyFormatter
    {
        private readonly IAccesibilityStereotyper _accesibilityStereotyper;
        private readonly IOverridingStereotyper _overridingStereotyper;
        private readonly ISymbolFormatter _symbolFormatter;

        public PropertyFormatter(IAccesibilityStereotyper accesibilityStereotyper,
                                 IOverridingStereotyper overridingStereotyper,
                                 ISymbolFormatter symbolFormatter)
        {
            _accesibilityStereotyper = accesibilityStereotyper;
            _overridingStereotyper = overridingStereotyper;
            _symbolFormatter = symbolFormatter;
        }

        public string Format(Property property)
        => _accesibilityStereotyper.GetStereotype(property.Accessibility)
            + _overridingStereotyper.GetStereotype(property.Overriding)
            + " "
            + _symbolFormatter.Format(property.Symbol);
    }
}
