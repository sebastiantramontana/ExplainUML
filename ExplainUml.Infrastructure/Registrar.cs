using Microsoft.Extensions.DependencyInjection;

namespace ExplainUml.Infrastructure
{
    internal class Registrar : IRegistrar
    {
        internal Registrar() { }

        private IServiceCollection _services = new ServiceCollection();

        public IRegistrar RegisterSingleton<TService, TImplementation>()
            where TImplementation : class, TService
            where TService : class
        {
            _services = _services.AddSingleton<TService, TImplementation>();
            return this;
        }

        public IRegistrar RegisterTransient<TService, TImplementation>()
            where TImplementation : class, TService
            where TService : class
        {
            _services = _services.AddTransient<TService, TImplementation>();
            return this;
        }

        public IServiceCollection Services => _services;
    }
}
