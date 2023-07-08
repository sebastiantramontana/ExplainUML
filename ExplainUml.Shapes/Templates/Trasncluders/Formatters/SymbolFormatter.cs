using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Trasncluders.Formatters
{
    internal class SymbolFormatter : ISymbolFormatter
    {
        public string Format(Symbol symbol) => $"{symbol.Name} : {symbol.Type.Name}";
    }
}
