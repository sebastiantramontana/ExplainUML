using ExplainUml.BuildingBlocks.Generics;
using ExplainUml.BuildingBlocks.Properties;

namespace ExplainUml.BuildingBlocks
{
    public interface IStructuralType : IBuildingBlock
    {
        public IEnumerable<TypeParameter> TypeParameters { get; }
        public IEnumerable<Interface> Interfaces { get; }
        public IEnumerable<Event> Events { get; }
        public IEnumerable<Property> Properties { get; }
        public IEnumerable<Method> Methods { get; }
    }
}
