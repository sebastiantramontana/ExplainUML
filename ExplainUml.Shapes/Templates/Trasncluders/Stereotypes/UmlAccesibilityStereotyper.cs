﻿using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Trasncluders.Stereotypes
{
    internal class UmlAccesibilityStereotyper : IAccesibilityStereotyper
    {
        public string GetStereotype(Accessibility accessibility)
            => accessibility switch
            {
                Accessibility.Public => "+",
                Accessibility.Private => "-",
                Accessibility.Protected => "#",
                Accessibility.Internal => "~",
                Accessibility.ProtectedInternal => "#~",
                Accessibility.PrivateProtected => "-#",
                _ => throw new NotImplementedException($"Accessibility {accessibility} not implemented")
            };
    }
}
