namespace ExplainUml.BuildingBlocks
{
    public class Symbol
    {
        public Symbol(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public Type Type { get; }
    }
}
