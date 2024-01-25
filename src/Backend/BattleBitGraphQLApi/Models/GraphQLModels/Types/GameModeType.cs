namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;

[GraphQLDescription("Supported game modes")]
public enum GameModeType
{
    [GraphQLDescription("None - was unable to prase value")]
    None,

    [GraphQLDescription("Conquest")]
    CONQ,

    [GraphQLDescription("CTF")]
    CaptureTheFlag,

    [GraphQLDescription("Domination")]
    DOMI,

    [GraphQLDescription("Elimination")]
    ELI,

    [GraphQLDescription("Free for all")]
    FFA,

    [GraphQLDescription("Frontline")]
    FRONTLINE,

    [GraphQLDescription("Gun game free for all")]
    GunGameFFA,

    [GraphQLDescription("Infantry Conquest")]
    INFCONQ,

    [GraphQLDescription("Rush")]
    RUSH,

    [GraphQLDescription("Team death match")]
    TDM,

    [GraphQLDescription("Voxel fortify")]
    VoxelFortify,

    [GraphQLDescription("Voxel trench")]
    VoxelTrench,
}