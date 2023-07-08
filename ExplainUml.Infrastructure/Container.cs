using Microsoft.Extensions.DependencyInjection;

namespace ExplainUml.Infrastructure
{
    internal class Container : IContainer
    {
        public Container()
        {
            ServiceProvider serviceProvider
            IServiceCollection services = new ServiceCollection();

            //Microsoft.Extensions.DependencyInjection
        }

        public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void RegisterTransient<TInterface, TImplementation>() where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }
    }
}
