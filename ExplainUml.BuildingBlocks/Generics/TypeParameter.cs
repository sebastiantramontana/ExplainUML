namespace ExplainUml.BuildingBlocks.Generics
{
    public class TypeParameter
    {
        public TypeParameter(string name, Variance? variance, TypeConstraint? typeConstraint, bool allowNew, TypeKindConstraint? typeKindConstraint)
        {
            Name = name;
            Variance = variance;
            TypeConstraint = typeConstraint;
            AllowNew = allowNew;
            TypeKindConstraint = typeKindConstraint;
        }

        public string Name { get; }
        public Variance? Variance { get; }
        public TypeConstraint? TypeConstraint { get; }
        public bool AllowNew { get; }
        public TypeKindConstraint? TypeKindConstraint { get; }
    }
}
