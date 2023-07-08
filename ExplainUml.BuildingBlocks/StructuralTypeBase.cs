using ExplainUml.BuildingBlocks.Generics;
using ExplainUml.BuildingBlocks.Properties;

namespace ExplainUml.BuildingBlocks
{
    public abstract class StructuralTypeBase : Type, IStructuralType
    {
        protected StructuralTypeBase(string name,
                     IEnumerable<TypeParameter> typeParameters,
                     IEnumerable<Interface> interfaces,
                     IEnumerable<Event> events,
                     IEnumerable<Property> properties,
                     IEnumerable<Method> methods) : base(name)
        {
            TypeParameters = typeParameters;
            Events = events;
            Properties = properties;
            Methods = methods;
            Interfaces = interfaces;
        }

        public IEnumerable<TypeParameter> TypeParameters { get; }
        public IEnumerable<Interface> Interfaces { get; }
        public IEnumerable<Event> Events { get; }
        public IEnumerable<Property> Properties { get; }
        public IEnumerable<Method> Methods { get; }
    }
}
