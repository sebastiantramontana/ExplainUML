using Microsoft.Extensions.DependencyInjection;

namespace ExplainUml.Infrastructure
{
    public interface IRegistrar
    {
        IRegistrar RegisterSingleton<TService, TImplementation>() where TImplementation : class, TService where TService : class;
        IRegistrar RegisterTransient<TService, TImplementation>() where TImplementation : class, TService where TService : class;
        internal IServiceCollection Services { get; }
    }
}