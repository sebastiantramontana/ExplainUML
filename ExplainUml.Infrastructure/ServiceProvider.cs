using Microsoft.Extensions.DependencyInjection;
using MSServiceProvider = System.IServiceProvider;

namespace ExplainUml.Infrastructure
{
    internal class ServiceProvider : IServiceProvider
    {
        private readonly MSServiceProvider _msServiceProvider;

        internal ServiceProvider(IRegistrar registrar)
        {

            _msServiceProvider = registrar.Services.BuildServiceProvider(new ServiceProviderOptions() { ValidateOnBuild = true });
        }

        public TService GetService<TService>()
            => _msServiceProvider.GetService<TService>() ?? throw new IoCException(typeof(TService));
    }
}
