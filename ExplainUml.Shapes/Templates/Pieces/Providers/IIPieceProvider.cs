namespace ExplainUml.Shapes.Templates.Pieces.Providers
{
    internal interface IPieceProvider
    {
        Task<string> GetPieceContent();
    }
}
