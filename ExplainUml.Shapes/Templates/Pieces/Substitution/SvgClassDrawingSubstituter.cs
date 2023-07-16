namespace ExplainUml.Shapes.Templates.Pieces.Substitution
{
    internal class SvgClassDrawingSubstituter : ISvgClassDrawingSubstituter
    {
        private const string BlockHeightTemplate = "{{BlockHeight}}";
        private const string ClassHeightTemplate = "{{ClassHeight}}";

        public string Substitute(int blockHeight, int classHeight, string classDrawingContentTemplate)
            => classDrawingContentTemplate
                .Replace(BlockHeightTemplate, blockHeight.ToString())
                .Replace(ClassHeightTemplate, classHeight.ToString());
    }
}
