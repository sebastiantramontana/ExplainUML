using System.Reflection;
using System.Text;

namespace ExplainUml.Shapes.Templates.Providers
{
    internal class SvgClassTemplateProvider : ISvgClassTemplateProvider
    {
        private const string FileName = "Class.svg";

        public async Task<string> GetTemplateContent()
        {
            var file = Assembly.GetExecutingAssembly().GetFile(FileName) ?? throw new FileNotFoundException(FileName);
            var bytes = new byte[file.Length];

            await file.ReadAsync(bytes);

            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
