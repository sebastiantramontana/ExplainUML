namespace ExplainUml.BuildingBlocks.Generics
{
    public class TypeConstraint
    {
        public TypeConstraint(Type type, bool isNullable)
        {
            Type = type;
            IsNullable = isNullable;
        }

        public Type Type { get; }
        public bool IsNullable { get; }
    }
}
