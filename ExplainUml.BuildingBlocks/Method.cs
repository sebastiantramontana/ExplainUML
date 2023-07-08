using ExplainUml.BuildingBlocks.Generics;

namespace ExplainUml.BuildingBlocks
{
    public class Method
    {
        public Method(string name,
                      IEnumerable<TypeParameter> typeParameters,
                      IEnumerable<Symbol> parameters,
                      Type returnType,
                      Accessibility accessibility,
                      Overriding overriding)
        {
            Name = name;
            TypeParameters = typeParameters;
            Parameters = parameters;
            ReturnType = returnType;
            Accessibility = accessibility;
            Overriding = overriding;
        }

        public string Name { get; }
        public IEnumerable<TypeParameter> TypeParameters { get; }
        public IEnumerable<Symbol> Parameters { get; }
        public Type ReturnType { get; }
        public Accessibility Accessibility { get; }
        public Overriding Overriding { get; }
    }
}
