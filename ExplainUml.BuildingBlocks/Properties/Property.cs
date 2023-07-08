namespace ExplainUml.BuildingBlocks.Properties
{
    public class Property
    {
        public Property(Symbol symbol, Accessibility accessibility, Overriding overriding, GetPropertyAccesor? getAccesor, SetPropertyAccesor? setAccesor)
        {
            Symbol = symbol;
            Accessibility = accessibility;
            Overriding = overriding;
            GetAccesor = getAccesor;
            SetAccesor = setAccesor;
        }

        public Symbol Symbol { get; }
        public Accessibility Accessibility { get; }
        public GetPropertyAccesor? GetAccesor { get; }
        public SetPropertyAccesor? SetAccesor { get; }
        public Overriding Overriding { get; }
    }
}
