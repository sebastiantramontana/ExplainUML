namespace ExplainUml.Shapes.Templates.Providers
{
    internal interface ITemplateProvider
    {
        Task<string> GetTemplateContent();
    }
}
