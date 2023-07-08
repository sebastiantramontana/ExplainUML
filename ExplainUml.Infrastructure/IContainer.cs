namespace ExplainUml.Infrastructure
{
    public interface IContainer
    {
        void RegisterSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface;
        void RegisterTransient<TInterface, TImplementation>() where TImplementation : class, TInterface;
    }
}