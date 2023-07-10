namespace ExplainUml.Infrastructure
{
    public static class Container
    {
        public static IRegistrar CreateRegistrar()
            => new Registrar();
        public static IServiceProvider CreateServiceProvider(IRegistrar registrar)
            => new ServiceProvider(registrar);
    }
}
