using ExplainUml.BuildingBlocks;
using ExplainUml.BuildingBlocks.Properties;
using ExplainUml.Shapes.Templates.Trasncluders.Formatters;
using System.Text;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal class SvgFieldsTranscluder : ISvgFieldsTranscluder
    {
        private const string BeginFieldBlockMark = "<!-- {{BEGIN FIELD BLOCK}} -->";
        private const string EndFieldBlockMark = "<!-- {{END FIELD BLOCK}} -->";
        private const string FieldSubstitution = "{{field}}";

        private readonly string Separator = Environment.NewLine + "<br>" + Environment.NewLine;

        private readonly IPropertyFormatter _propertyFormatter;
        private readonly IEventFormatter _eventFormatter;

        public SvgFieldsTranscluder(IPropertyFormatter propertyFormatter, IEventFormatter eventFormatter)
        {
            _propertyFormatter = propertyFormatter;
            _eventFormatter = eventFormatter;
        }

        public string Transclude(IEnumerable<Property> properties, IEnumerable<Event> events, string templateContent)
        {
            var fieldBlock = GetFieldBlock(templateContent);
            var fields = CreateFieldsBlock(properties, events, fieldBlock);

            return templateContent.Replace(fieldBlock, fields);
        }

        private string CreateFieldsBlock(IEnumerable<Property> properties, IEnumerable<Event> events, string fieldBlock)
        {
            var eventsBlock = CreateEventsBlock(events, fieldBlock);
            var propertiesBlock = CreatePropertiesBlock(properties, fieldBlock);
            var stringBuilder = new StringBuilder();

            return stringBuilder
                .AppendJoin(Separator, eventsBlock, propertiesBlock)
                .ToString();
        }

        private string CreateEventsBlock(IEnumerable<Event> events, string fieldBlock)
        {
            var stringBuilder = new StringBuilder();

            foreach (var @event in events)
            {
                stringBuilder.AppendLine(ReplaceField(@event, fieldBlock));
                stringBuilder.AppendLine(Separator);
            }

            return stringBuilder.ToString();
        }

        private string CreatePropertiesBlock(IEnumerable<Property> properties, string fieldBlock)
        {
            var stringBuilder = new StringBuilder();

            foreach (var property in properties)
            {
                stringBuilder.AppendLine(ReplaceField(property, fieldBlock));
                stringBuilder.AppendLine(Separator);
            }

            return stringBuilder.ToString();
        }

        private string ReplaceField(Property property, string templateFieldBlock)
            => templateFieldBlock.Replace(FieldSubstitution, _propertyFormatter.Format(property));

        private string ReplaceField(Event @event, string templateFieldBlock)
            => templateFieldBlock.Replace(FieldSubstitution, _eventFormatter.Format(@event));

        private string GetFieldBlock(string templateContent)
        {
            var fieldBlockStartIndex = GetFieldBlockStartIndex(templateContent);
            var fieldBlockEndIndex = GetFieldBlockEndIndex(templateContent);
            var length = fieldBlockEndIndex - fieldBlockStartIndex;

            return templateContent.Substring(fieldBlockStartIndex, length).Trim();
        }

        private int GetFieldBlockStartIndex(string templateContent)
            => templateContent.IndexOf(BeginFieldBlockMark, StringComparison.InvariantCulture);

        private int GetFieldBlockEndIndex(string templateContent)
            => templateContent.IndexOf(EndFieldBlockMark, StringComparison.InvariantCulture) + EndFieldBlockMark.Length;
    }
}
