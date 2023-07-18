﻿using ExplainUml.BuildingBlocks;
using ExplainUml.BuildingBlocks.Properties;
using ExplainUml.Shapes.Templates.Pieces.Providers.Class;
using ExplainUml.Shapes.Templates.Pieces.Substitution;
using ExplainUml.Shapes.Templates.Trasncluders.Formatters;

namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal class SvgClassFieldsService : SvgBlockServiceBase, ISvgClassFieldsService
    {
        private const int InitialPositionY = 45;
        private const int InitialPaddingTop = 33;

        private readonly ISvgClassFieldPieceProvider _svgClassFieldPieceProvider;
        private readonly IEventFormatter _eventFormatter;
        private readonly IPropertyFormatter _propertyFormatter;

        public SvgClassFieldsService(ISvgClassFieldPieceProvider svgClassFieldPieceProvider, ISvgClassFieldSubstituter svgClassFieldSubstituter, IEventFormatter eventFormatter, IPropertyFormatter propertyFormatter)
            : base(svgClassFieldSubstituter)
        {
            _svgClassFieldPieceProvider = svgClassFieldPieceProvider;
            _eventFormatter = eventFormatter;
            _propertyFormatter = propertyFormatter;
        }

        public async Task<string> GetFieldsContent(IEnumerable<Event> events, IEnumerable<Property> properties)
        {
            var pieceContent = await _svgClassFieldPieceProvider.GetPieceContent();

            var fields = new List<string>();
            fields.AddRange(FormatEvents(events));
            fields.AddRange(FormatProperties(properties));

            return GetBlocksContent(fields, InitialPositionY, InitialPaddingTop, pieceContent));
        }

        private IEnumerable<string> FormatEvents(IEnumerable<Event> events)
            => events.Select(e => _eventFormatter.Format(e));

        private IEnumerable<string> FormatProperties(IEnumerable<Property> properties)
            => properties.Select(p => _propertyFormatter.Format(p));
    }
}
