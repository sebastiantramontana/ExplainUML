using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Services
{
    public interface ISvgShapeService<TBuildingBlock> where TBuildingBlock : IBuildingBlock
    {
        Task<string> GetBase64Image(TBuildingBlock buildingBlock);
    }
}
