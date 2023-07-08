namespace ExplainUml.BuildingBlocks
{
    public class Type : IBuildingBlock
    {
        public Type(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
