namespace ExplainUml.Shapes.Templates.Pieces.Providers
{
    internal abstract class SvgPiecesPathBase : ISvgPiecesPath
    {
        private const string Path = "ExplainUml.Shapes.Templates.Pieces.Files";
        private readonly string _subFolder;

        protected SvgPiecesPathBase(string subFolder)
        {
            _subFolder = subFolder;
        }

        public string GetFilePath(string filename)
            => string.Join('.', Path, _subFolder, filename);
    }
}
