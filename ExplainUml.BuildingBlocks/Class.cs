using ExplainUml.BuildingBlocks.Generics;
using ExplainUml.BuildingBlocks.Properties;

namespace ExplainUml.BuildingBlocks
{
    public class Class : StructuralTypeBase
    {
        public Class(string name,
                     IEnumerable<TypeParameter> typeParameters,
                     Class? baseClass,
                     IEnumerable<Interface> interfaces,
                     IEnumerable<Event> events,
                     IEnumerable<Property> properties,
                     IEnumerable<Method> methods)
            : base(name, typeParameters, interfaces, events, properties, methods)
        {
            BaseClass = baseClass;
        }

        public Class? BaseClass { get; }
    }
}