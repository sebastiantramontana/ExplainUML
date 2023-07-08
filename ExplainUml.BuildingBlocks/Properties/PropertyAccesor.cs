namespace ExplainUml.BuildingBlocks.Properties
{
    public abstract class PropertyAccesor
    {
        protected PropertyAccesor(Accessibility? accessibility)
        {
            Accessibility = accessibility;
        }

        public Accessibility? Accessibility { get; }
    }
}
