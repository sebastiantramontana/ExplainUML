using System.ComponentModel.Design;

namespace ExplainUml.Infrastructure
{
    public class IoCException : Exception
    {
        public IoCException(Type serviceType)
            : base($"Service {serviceType.Name} no registrado") { }
    }
}
