namespace ExplainUml.Shapes.Templates.Pieces.Providers
{
    internal interface IPieceReader
    {
        Task<string> Read(string fileName);
    }
}
