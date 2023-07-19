using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Pieces.Services;
using System.Text;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal class SvgClassTrasncluder : ISvgClassTrasncluder
    {
        private const int PaddingTopPositionYDifference = 12;

        private const int ClassNameInitialPositionY = 19;
        private const int ClassNameInitialPaddingTop = ClassNameInitialPositionY - PaddingTopPositionYDifference;

        private const int FieldsInitialPositionY = 45;
        private const int FieldsInitialPaddingTop = FieldsInitialPositionY - PaddingTopPositionYDifference;

        private readonly ISvgClassBeginService _beginService;
        private readonly ISvgClassDrawingPieceService _drawingPieceService;
        private readonly ISvgClassNameService _classNameService;
        private readonly ISvgClassFieldsService _fieldsService;
        private readonly ISvgClassSeparatorService _separatorService;
        private readonly ISvgClassMethodsService _methodsService;
        private readonly ISvgClassEndService _endService;

        public SvgClassTrasncluder(ISvgClassBeginService beginService,
                                   ISvgClassDrawingPieceService drawingPieceService,
                                   ISvgClassNameService classNameService,
                                   ISvgClassFieldsService fieldsService,
                                   ISvgClassSeparatorService separatorService,
                                   ISvgClassMethodsService methodsService,
                                   ISvgClassEndService endService)
        {
            _beginService = beginService;
            _drawingPieceService = drawingPieceService;
            _classNameService = classNameService;
            _fieldsService = fieldsService;
            _separatorService = separatorService;
            _methodsService = methodsService;
            _endService = endService;
        }

        public async Task<string> Transclude(Class @class)
        {
            var stringBuilder = new StringBuilder();
            var methodsPositionY = CalculateMethodsPositionY(@class);

            stringBuilder.AppendLine(await _beginService.GetBeginContent());
            stringBuilder.AppendLine(await _drawingPieceService.GetDrawingContent(@class));
            stringBuilder.AppendLine(await _classNameService.GetClassNameContent(@class.Name, ClassNameInitialPositionY, ClassNameInitialPaddingTop));
            stringBuilder.AppendLine(await _fieldsService.GetFieldsContent(@class.Events, @class.Properties, FieldsInitialPositionY, FieldsInitialPaddingTop));
            stringBuilder.AppendLine(await _separatorService.GetSeparatorContent(CalculateSeparatorPositionY(methodsPositionY)));
            stringBuilder.AppendLine(await _methodsService.GetMethodsContent(@class.Methods, methodsPositionY, CalculateMethodPaddingTop(methodsPositionY)));
            stringBuilder.AppendLine(await _endService.GetEndContent());

            return stringBuilder.ToString();
        }

        private int CalculateSeparatorPositionY(int methodPositionY)
        {
            return methodPositionY - SvgClassInfo.DivisionSeparatorHeight / 2;
        }

        private int CalculateMethodsPositionY(Class @class)
            => (1 + @class.Events.Count() + @class.Properties.Count()) * SvgClassInfo.BlockHeight + SvgClassInfo.DivisionSeparatorHeight;

        private int CalculateMethodPaddingTop(int methodPositionY) => methodPositionY - PaddingTopPositionYDifference;


    }
}
