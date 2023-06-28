namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;

[GraphQLDescription("Supported hosting regions")]
public enum RegionType
{
    [GraphQLDescription("None - was unable to parse value")]
    None,

    [GraphQLDescription("Central America")]
    America_Central,

    [GraphQLDescription("Central Australia")]
    Australia_Central,

    [GraphQLDescription("Central Brazil")]
    Brazil_Central,

    [GraphQLDescription("Central Europe")]
    Europe_Central,

    [GraphQLDescription("Central Japan")]
    Japan_Central
}