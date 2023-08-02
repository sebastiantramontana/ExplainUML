using ExplainUml.BuildingBlocks;
using ExplainUml.BuildingBlocks.Generics;
using ExplainUml.BuildingBlocks.Properties;
using ExplainUml.Infrastructure;
using ExplainUml.Shapes.Services;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Media.Media3D;
using System.Windows.Media;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public MainWindow()
        {
            InitializeComponent();

            _serviceProvider = Register();
            diagram.NavigationCompleted += Diagram_NavigationCompleted;

        }

        private IServiceProvider Register()
        {
            var registrar = Container.CreateRegistrar();
            registrar = ExplainUml.Shapes.IoC.Registrar.RegisterServices(registrar);
            return Container.CreateServiceProvider(registrar);
        }

        private async void Diagram_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            diagram.CoreWebView2.Settings.IsScriptEnabled = true;
            diagram.CoreWebView2.Settings.IsWebMessageEnabled = true;

            var aver = await diagram.ExecuteScriptAsync("var jsEditor = window.document.createElement('script'); " +
                                                        "jsEditor.src='http://jgraph.github.io/drawio-integration/diagram-editor.js'; " +
                                                        "window.document.body.appendChild(jsEditor); ");
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var script = "var img = window.document.createElement('img'); " +
                                                        $"img.src='{await GetImgSource()}'; " +
                                                        $"DiagramEditor.editElement(img, null, null, null, ['proto=json', 'spin=1','ui=dark','libraries=1','saveAndExit=0&noSaveBtn=0&noExitBtn=1','pv=0']);";
            await diagram.ExecuteScriptAsync(script);
        }

        private Task<string> GetImgSource()
        {
            var @class = new Class("Aver",
                                   new TypeParameter[0],
                                   null,
                                   new Interface[0],
                                   new[] { new Event("AverEvent") },
                                   new[] { new Property(new Symbol("averProperty", new Type("averType")), ExplainUml.BuildingBlocks.Accessibility.Public, Overriding.None, null, null) },
                                   new[] { new Method("averMethod", new TypeParameter[0], new Symbol[0], new Type("void"), ExplainUml.BuildingBlocks.Accessibility.Public, Overriding.None) });

            var classService = _serviceProvider.GetService<ISvgShapeService<Class>>();
            return classService.GetBase64Image(@class);

            //return Task.FromResult("data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4NCjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+DQo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHZlcnNpb249IjEuMSIgd2lkdGg9IjEyMXB4IiBoZWlnaHQ9IjYxcHgiIHZpZXdCb3g9Ii0wLjUgLTAuNSAxMjEgNjEiIGNvbnRlbnQ9IiZsdDtteGZpbGUgZXRhZz0mcXVvdDtUZ0FHYkpsY0lobDdrUm5EYXFINCZxdW90OyBhZ2VudD0mcXVvdDtNb3ppbGxhLzUuMCAoTWFjaW50b3NoOyBJbnRlbCBNYWMgT1MgWCAxMF8xNF82KSBBcHBsZVdlYktpdC81MzcuMzYgKEtIVE1MLCBsaWtlIEdlY2tvKSBDaHJvbWUvODAuMC4zOTg3LjEwNiBTYWZhcmkvNTM3LjM2JnF1b3Q7IG1vZGlmaWVkPSZxdW90OzIwMjAtMDItMTlUMTI6NDQ6MjcuNjU5WiZxdW90OyBob3N0PSZxdW90O3Rlc3QuZHJhdy5pbyZxdW90OyB2ZXJzaW9uPSZxdW90O0BEUkFXSU8tVkVSU0lPTkAmcXVvdDsmZ3Q7Jmx0O2RpYWdyYW0gaWQ9JnF1b3Q7clV1eHZtYW1kTloxenJMWE9sXzYmcXVvdDsgbmFtZT0mcXVvdDtQYWdlLTEmcXVvdDsmZ3Q7bFpQTGJzSXdFRVcvSmtza3g2WXRXd29wZmFpbEtxcVEySmw0Y0Z3NUdlUVlTUHIxVFlpZEJ5emFyakkrbVVmbVhpZGdzN1JZR0w1UFhsR0FEaWdSUmNEbUFhVWhwYXg2MUtSc3lWMURwRkhDc1E2czFEYzRTQnc5S0FINUlORWlhcXYyUXhoamxrRnNCNHdiZzZkaDJnNzFjT3FlUzdnQ3E1anJhN3BXd2lZTm5keVFqaitDa29tZkhCTDNKdVUrMllFODRRSlBQY1NpZ00wTW9tMml0SmlCcnRYenVyeUY3L014WlIramJFTmlTYWZSUnFwUjAremhQeVh0Q2dZeSs5Zlduem1ZNWZhcmxwUVN6YmVWcitmS2xlWEdOZzM5ME95d0hkdW5ZMWdzWDliUGJJZTRMcWVqYnNQMkkzTmJlbFVOSGpJQmRUMEoyTDNVUE05ZDNLcFVINW81UnpBV2lnczdmdGtsN0kxZkFLWmdUVm5WdVM3TWUrSnU1Y1FkVDUzRG9VOUpldTdlT3NiZHBaSnQ1MDY0S25BYisyTlBTbzg2MTgvcHZaK0hSVDg9Jmx0Oy9kaWFncmFtJmd0OyZsdDsvbXhmaWxlJmd0OyIgc3R5bGU9ImJhY2tncm91bmQtY29sb3I6IHJnYigyNTUsIDI1NSwgMjU1KTsiPjxkZWZzLz48Zz48cmVjdCB4PSIwIiB5PSIwIiB3aWR0aD0iMTIwIiBoZWlnaHQ9IjYwIiBmaWxsPSIjZmZmZmZmIiBzdHJva2U9IiMwMDAwMDAiIHBvaW50ZXItZXZlbnRzPSJhbGwiLz48ZyBmaWxsPSIjMDAwMDAwIiBmb250LWZhbWlseT0iSGVsdmV0aWNhIiB0ZXh0LWFuY2hvcj0ibWlkZGxlIiBmb250LXNpemU9IjEycHgiPjx0ZXh0IHg9IjU5LjUiIHk9IjM0LjUiPkNhY2hvPC90ZXh0PjwvZz48L2c+PC9zdmc+");
            //data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2ZXJzaW9uPSIxLjEiIHdpZHRoPSIxMjFweCIgaGVpZ2h0PSI2MXB4IiB2aWV3Qm94PSItMC41IC0wLjUgMTIxIDYxIiBjb250ZW50PSImbHQ7bXhmaWxlIGhvc3Q9JnF1b3Q7ZW1iZWQuZGlhZ3JhbXMubmV0JnF1b3Q7IG1vZGlmaWVkPSZxdW90OzIwMjEtMTAtMDdUMDM6MjU6NTEuNDU5WiZxdW90OyBhZ2VudD0mcXVvdDs1LjAgKE1hY2ludG9zaDsgSW50ZWwgTWFjIE9TIFggMTBfMTVfNykgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzk0LjAuNDYwNi43MSBTYWZhcmkvNTM3LjM2JnF1b3Q7IGV0YWc9JnF1b3Q7eUM3cDVNMGpfaDJ2MFh3NDB3b2UmcXVvdDsgdmVyc2lvbj0mcXVvdDsxNS40LjMmcXVvdDsgdHlwZT0mcXVvdDtlbWJlZCZxdW90OyZndDsmbHQ7ZGlhZ3JhbSBpZD0mcXVvdDtlbVlSU0REUmtEUDJZZDNFWnkzciZxdW90OyBuYW1lPSZxdW90O1BhZ2UtMSZxdW90OyZndDtqWkpCVDRVd0RJQi96YTdtd1NMaVZYdytMNTR3OFR4WlpZdGpJNk04d0Y4dmM1dXdFQk12Vy91MWE3dTJoRmJkZkxHc0Z5K0dneUw1aWMrRVBwSTh6Mjd2c3ZWeVpQR2tLRXNQV2l1NVI2Y04xUElMd3N0SVI4bGhDTXdqTkVhaDdGUFlHSzJod1lReGE4MlV1bjBZbFdidFdRc0hVRGRNUWZMTzBUZkpVWGhhNXNYR24wRzJJbWJPaW50dmVXZk5aMnZOcUVNK2JUUjRTOGRpbUpCeUVJeWJhWWZvbWRES0dvTmU2dVlLbEd0cjJyR25QNnloNUFHWCtJbFlxd1dOLzRvUVAzRmxhZ3d4WG9VY25JczdtSnNDREhoenlEUUppVkQzckhINnRLNEVvUThDTzdWcTJTb2VDd25GWHNFaXpEc1VDcnVBNlFEdHNyb0VhMnpha3FyVE5wd3NNckViVEJFWUMvdlEvZ2JlK3JBS29SVlIzV2J3WTl2dE9EMS9Bdz09Jmx0Oy9kaWFncmFtJmd0OyZsdDsvbXhmaWxlJmd0OyI+PGRlZnMvPjxnPjxyZWN0IHg9IjAiIHk9IjAiIHdpZHRoPSIxMjAiIGhlaWdodD0iNjAiIGZpbGw9IiNmZmZmZmYiIHN0cm9rZT0iIzAwMDAwMCIgcG9pbnRlci1ldmVudHM9ImFsbCIvPjxnIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0wLjUgLTAuNSkiPjxzd2l0Y2g+PGZvcmVpZ25PYmplY3QgcG9pbnRlci1ldmVudHM9Im5vbmUiIHdpZHRoPSIxMDAlIiBoZWlnaHQ9IjEwMCUiIHJlcXVpcmVkRmVhdHVyZXM9Imh0dHA6Ly93d3cudzMub3JnL1RSL1NWRzExL2ZlYXR1cmUjRXh0ZW5zaWJpbGl0eSIgc3R5bGU9Im92ZXJmbG93OiB2aXNpYmxlOyB0ZXh0LWFsaWduOiBsZWZ0OyI+PGRpdiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94aHRtbCIgc3R5bGU9ImRpc3BsYXk6IGZsZXg7IGFsaWduLWl0ZW1zOiB1bnNhZmUgY2VudGVyOyBqdXN0aWZ5LWNvbnRlbnQ6IHVuc2FmZSBjZW50ZXI7IHdpZHRoOiAxMThweDsgaGVpZ2h0OiAxcHg7IHBhZGRpbmctdG9wOiAzMHB4OyBtYXJnaW4tbGVmdDogMXB4OyI+PGRpdiBzdHlsZT0iYm94LXNpemluZzogYm9yZGVyLWJveDsgZm9udC1zaXplOiAwcHg7IHRleHQtYWxpZ246IGNlbnRlcjsiPjxkaXYgc3R5bGU9ImRpc3BsYXk6IGlubGluZS1ibG9jazsgZm9udC1zaXplOiAxMnB4OyBmb250LWZhbWlseTogSGVsdmV0aWNhOyBjb2xvcjogcmdiKDAsIDAsIDApOyBsaW5lLWhlaWdodDogMS4yOyBwb2ludGVyLWV2ZW50czogYWxsOyB3aGl0ZS1zcGFjZTogbm9ybWFsOyBvdmVyZmxvdy13cmFwOiBub3JtYWw7Ij5UaGlzIGlzIGEgdGVzdC48L2Rpdj48L2Rpdj48L2Rpdj48L2ZvcmVpZ25PYmplY3Q+PHRleHQgeD0iNjAiIHk9IjM0IiBmaWxsPSIjMDAwMDAwIiBmb250LWZhbWlseT0iSGVsdmV0aWNhIiBmb250LXNpemU9IjEycHgiIHRleHQtYW5jaG9yPSJtaWRkbGUiPlRoaXMgaXMgYSB0ZXN0LjwvdGV4dD48L3N3aXRjaD48L2c+PC9nPjxzd2l0Y2g+PGcgcmVxdWlyZWRGZWF0dXJlcz0iaHR0cDovL3d3dy53My5vcmcvVFIvU1ZHMTEvZmVhdHVyZSNFeHRlbnNpYmlsaXR5Ii8+PGEgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCwtNSkiIHhsaW5rOmhyZWY9Imh0dHBzOi8vd3d3LmRpYWdyYW1zLm5ldC9kb2MvZmFxL3N2Zy1leHBvcnQtdGV4dC1wcm9ibGVtcyIgdGFyZ2V0PSJfYmxhbmsiPjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIGZvbnQtc2l6ZT0iMTBweCIgeD0iNTAlIiB5PSIxMDAlIj5WaWV3ZXIgZG9lcyBub3Qgc3VwcG9ydCBmdWxsIFNWRyAxLjE8L3RleHQ+PC9hPjwvc3dpdGNoPjwvc3ZnPg==
            //return Task.FromResult("data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hsaW5rIiB2ZXJzaW9uPSIxLjEiIHdpZHRoPSIxMjFweCIgaGVpZ2h0PSI2MXB4IiB2aWV3Qm94PSItMC41IC0wLjUgMTIxIDYxIiBjb250ZW50PSImbHQ7bXhmaWxlIGhvc3Q9JnF1b3Q7ZW1iZWQuZGlhZ3JhbXMubmV0JnF1b3Q7IG1vZGlmaWVkPSZxdW90OzIwMjEtMTAtMDdUMDM6MjU6NTEuNDU5WiZxdW90OyBhZ2VudD0mcXVvdDs1LjAgKE1hY2ludG9zaDsgSW50ZWwgTWFjIE9TIFggMTBfMTVfNykgQXBwbGVXZWJLaXQvNTM3LjM2IChLSFRNTCwgbGlrZSBHZWNrbykgQ2hyb21lLzk0LjAuNDYwNi43MSBTYWZhcmkvNTM3LjM2JnF1b3Q7IGV0YWc9JnF1b3Q7eUM3cDVNMGpfaDJ2MFh3NDB3b2UmcXVvdDsgdmVyc2lvbj0mcXVvdDsxNS40LjMmcXVvdDsgdHlwZT0mcXVvdDtlbWJlZCZxdW90OyZndDsmbHQ7ZGlhZ3JhbSBpZD0mcXVvdDtlbVlSU0REUmtEUDJZZDNFWnkzciZxdW90OyBuYW1lPSZxdW90O1BhZ2UtMSZxdW90OyZndDtqWkpCVDRVd0RJQi96YTdtd1NMaVZYdytMNTR3OFR4WlpZdGpJNk04d0Y4dmM1dXdFQk12Vy91MWE3dTJoRmJkZkxHc0Z5K0dneUw1aWMrRVBwSTh6Mjd2c3ZWeVpQR2tLRXNQV2l1NVI2Y04xUElMd3N0SVI4bGhDTXdqTkVhaDdGUFlHSzJod1lReGE4MlV1bjBZbFdidFdRc0hVRGRNUWZMTzBUZkpVWGhhNXNYR24wRzJJbWJPaW50dmVXZk5aMnZOcUVNK2JUUjRTOGRpbUpCeUVJeWJhWWZvbWRES0dvTmU2dVlLbEd0cjJyR25QNnloNUFHWCtJbFlxd1dOLzRvUVAzRmxhZ3d4WG9VY25JczdtSnNDREhoenlEUUppVkQzckhINnRLNEVvUThDTzdWcTJTb2VDd25GWHNFaXpEc1VDcnVBNlFEdHNyb0VhMnpha3FyVE5wd3NNckViVEJFWUMvdlEvZ2JlK3JBS29SVlIzV2J3WTl2dE9EMS9Bdz09Jmx0Oy9kaWFncmFtJmd0OyZsdDsvbXhmaWxlJmd0OyI+PGRlZnMvPjxnPjxyZWN0IHg9IjAiIHk9IjAiIHdpZHRoPSIxMjAiIGhlaWdodD0iNjAiIGZpbGw9IiNmZmZmZmYiIHN0cm9rZT0iIzAwMDAwMCIgcG9pbnRlci1ldmVudHM9ImFsbCIvPjxnIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0wLjUgLTAuNSkiPjxzd2l0Y2g+PGZvcmVpZ25PYmplY3QgcG9pbnRlci1ldmVudHM9Im5vbmUiIHdpZHRoPSIxMDAlIiBoZWlnaHQ9IjEwMCUiIHJlcXVpcmVkRmVhdHVyZXM9Imh0dHA6Ly93d3cudzMub3JnL1RSL1NWRzExL2ZlYXR1cmUjRXh0ZW5zaWJpbGl0eSIgc3R5bGU9Im92ZXJmbG93OiB2aXNpYmxlOyB0ZXh0LWFsaWduOiBsZWZ0OyI+PGRpdiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94aHRtbCIgc3R5bGU9ImRpc3BsYXk6IGZsZXg7IGFsaWduLWl0ZW1zOiB1bnNhZmUgY2VudGVyOyBqdXN0aWZ5LWNvbnRlbnQ6IHVuc2FmZSBjZW50ZXI7IHdpZHRoOiAxMThweDsgaGVpZ2h0OiAxcHg7IHBhZGRpbmctdG9wOiAzMHB4OyBtYXJnaW4tbGVmdDogMXB4OyI+PGRpdiBzdHlsZT0iYm94LXNpemluZzogYm9yZGVyLWJveDsgZm9udC1zaXplOiAwcHg7IHRleHQtYWxpZ246IGNlbnRlcjsiPjxkaXYgc3R5bGU9ImRpc3BsYXk6IGlubGluZS1ibG9jazsgZm9udC1zaXplOiAxMnB4OyBmb250LWZhbWlseTogSGVsdmV0aWNhOyBjb2xvcjogcmdiKDAsIDAsIDApOyBsaW5lLWhlaWdodDogMS4yOyBwb2ludGVyLWV2ZW50czogYWxsOyB3aGl0ZS1zcGFjZTogbm9ybWFsOyBvdmVyZmxvdy13cmFwOiBub3JtYWw7Ij5UaGlzIGlzIGEgdGVzdC48L2Rpdj48L2Rpdj48L2Rpdj48L2ZvcmVpZ25PYmplY3Q+PHRleHQgeD0iNjAiIHk9IjM0IiBmaWxsPSIjMDAwMDAwIiBmb250LWZhbWlseT0iSGVsdmV0aWNhIiBmb250LXNpemU9IjEycHgiIHRleHQtYW5jaG9yPSJtaWRkbGUiPlRoaXMgaXMgYSB0ZXN0LjwvdGV4dD48L3N3aXRjaD48L2c+PC9nPjxzd2l0Y2g+PGcgcmVxdWlyZWRGZWF0dXJlcz0iaHR0cDovL3d3dy53My5vcmcvVFIvU1ZHMTEvZmVhdHVyZSNFeHRlbnNpYmlsaXR5Ii8+PGEgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCwtNSkiIHhsaW5rOmhyZWY9Imh0dHBzOi8vd3d3LmRpYWdyYW1zLm5ldC9kb2MvZmFxL3N2Zy1leHBvcnQtdGV4dC1wcm9ibGVtcyIgdGFyZ2V0PSJfYmxhbmsiPjx0ZXh0IHRleHQtYW5jaG9yPSJtaWRkbGUiIGZvbnQtc2l6ZT0iMTBweCIgeD0iNTAlIiB5PSIxMDAlIj5WaWV3ZXIgZG9lcyBub3Qgc3VwcG9ydCBmdWxsIFNWRyAxLjE8L3RleHQ+PC9hPjwvc3dpdGNoPjwvc3ZnPg==");
        }
    }
}
