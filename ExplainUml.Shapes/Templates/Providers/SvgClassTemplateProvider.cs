using System.Reflection;
using System.Text;

namespace ExplainUml.Shapes.Templates.Providers
{
    internal class SvgClassTemplateProvider : ISvgClassTemplateProvider
    {
        private const string FileName = "ExplainUml.Shapes.Templates.Files.Class.svg";

        public async Task<string> GetTemplateContent()
        {
            var file = Assembly.GetAssembly(typeof(SvgClassTemplateProvider))!.GetManifestResourceStream(FileName) ?? throw new FileNotFoundException(FileName);
            var bytes = new byte[file!.Length];

            await file.ReadAsync(bytes);

            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
