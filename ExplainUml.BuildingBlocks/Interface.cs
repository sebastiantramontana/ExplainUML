using ExplainUml.BuildingBlocks.Generics;
using ExplainUml.BuildingBlocks.Properties;

namespace ExplainUml.BuildingBlocks
{
    public class Interface : StructuralTypeBase
    {
        public Interface(string name,
                         IEnumerable<TypeParameter> typeParameters,
                         IEnumerable<Interface> interfaces,
                         IEnumerable<Event> events,
                         IEnumerable<Property> properties,
                         IEnumerable<Method> methods)
            : base(name, typeParameters, interfaces, events, properties, methods)
        {
        }
    }
}
