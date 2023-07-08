using ExplainUml.BuildingBlocks;
using ExplainUml.Shapes.Templates.Trasncluders.Formatters;
using System.Text;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal class SvgMethodsTranscluder : ISvgMethodsTranscluder
    {
        private const string BeginMethodBlockMark = "<!-- {{BEGIN METHOD BLOCK}} -->";
        private const string EndMethodBlockMark = "<!-- {{END METHOD BLOCK}} -->";
        private const string MethodSubstitution = "{{method}}";

        private readonly string Separator = Environment.NewLine + "<br>" + Environment.NewLine;

        private readonly IMethodFormatter _methodFormatter;

        public SvgMethodsTranscluder(IMethodFormatter methodFormatter)
        {
            _methodFormatter = methodFormatter;
        }

        public string Tranclude(IEnumerable<Method> methods, string templateContent)
        {
            var templateMethodBlock = GetMethodBlock(templateContent);
            var newMethodsBlock = CreateMethodsBlock(methods, templateMethodBlock);

            return templateContent.Replace(templateMethodBlock, newMethodsBlock);
        }

        private string CreateMethodsBlock(IEnumerable<Method> methods, string methodBlock)
        {
            var stringBuilder = new StringBuilder();

            foreach (var method in methods)
            {
                stringBuilder.AppendLine(ReplaceMethod(method, methodBlock));
                stringBuilder.AppendLine(Separator);
            }

            return stringBuilder.ToString();
        }

        private string ReplaceMethod(Method method, string templatemethoddBlock)
            => templatemethoddBlock.Replace(MethodSubstitution, _methodFormatter.Format(method));

        private string GetMethodBlock(string templateContent)
        {
            var methodBlockStartIndex = GetMethoddBlockStartIndex(templateContent);
            var methodBlockEndIndex = GetMethodBlockEndIndex(templateContent);
            var length = methodBlockEndIndex - methodBlockStartIndex;

            return templateContent.Substring(methodBlockStartIndex, length).Trim();
        }

        private int GetMethoddBlockStartIndex(string templateContent)
            => templateContent.IndexOf(BeginMethodBlockMark, StringComparison.InvariantCulture) + BeginMethodBlockMark.Length;

        private int GetMethodBlockEndIndex(string templateContent)
            => templateContent.IndexOf(EndMethodBlockMark, StringComparison.InvariantCulture) + EndMethodBlockMark.Length;
    }
}
