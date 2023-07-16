using ExplainUml.BuildingBlocks;

namespace ExplainUml.Shapes.Templates.Trasncluders
{
    internal interface ITrasncluder<TBuildingBlock> where TBuildingBlock : IBuildingBlock
    {
        string Transclude(TBuildingBlock buildingBlock);
    }
}
