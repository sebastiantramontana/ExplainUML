using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Trasncluders.Formatters
{
    internal class EventFormatter : IEventFormatter
    {
        public string Format(Event @event) => "⚡ " + @event.Name;
    }
}
