using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Pieces.Services;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal class SvgClassTrasncluder : ISvgClassTrasncluder
    {
        private readonly ISvgClassBeginService _beginService;
        private readonly ISvgClassNameService _classNameService;
        private readonly ISvgClassFieldsService _fieldsService;
        private readonly ISvgClassSeparatorService _separatorService;
        private readonly ISvgClassMethodsService _methodsService;
        private readonly ISvgClassEndService _endService;

        public SvgClassTrasncluder(ISvgClassBeginService beginService,
                                   ISvgClassNameService classNameService,
                                   ISvgClassFieldsService fieldsService,
                                   ISvgClassSeparatorService separatorService,
                                   ISvgClassMethodsService methodsService,
                                   ISvgClassEndService endService)
        {
            _beginService = beginService;
            _classNameService = classNameService;
            _fieldsService = fieldsService;
            _separatorService = separatorService;
            _methodsService = methodsService;
            _endService = endService;
        }

        public Task<string> Transclude(Class @class)
        {

        }
    }
}
