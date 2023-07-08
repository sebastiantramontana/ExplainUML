using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Trasncluders.Stereotypes
{
    internal class OverridingStereotyper : IOverridingStereotyper
    {
        public string GetStereotype(Overriding overriding)
            => overriding switch
            {
                Overriding.None => string.Empty,
                Overriding.Virtual => "V",
                Overriding.Abstract => "A",
                Overriding.Override => "O",
                Overriding.AbstractOverride => "AO",
                Overriding.New => "N",
                _ => throw new NotImplementedException($"Overriding {overriding} not supported"),
            };
    }
}
