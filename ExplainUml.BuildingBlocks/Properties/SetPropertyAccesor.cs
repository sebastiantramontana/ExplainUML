namespace ExplainUml.BuildingBlocks.Properties
{
    public class SetPropertyAccesor : PropertyAccesor
    {
        public SetPropertyAccesor(Accessibility? accessibility, bool isInit, bool isRequired) : base(accessibility)
        {
            IsInit = isInit;
            IsRequired = isRequired;
        }

        public bool IsInit { get; }
        public bool IsRequired { get; }
    }
}
