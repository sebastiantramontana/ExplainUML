namespace ExplainUml.Infrastructure
{
    public interface IServiceProvider
    {
        TService GetService<TService>();
    }
}
