namespace ExplainUml.Shapes.Templates.Pieces.Services
{
    internal interface IDeflater
    {
        Task<byte[]> Deflate(string content);
    }
}
