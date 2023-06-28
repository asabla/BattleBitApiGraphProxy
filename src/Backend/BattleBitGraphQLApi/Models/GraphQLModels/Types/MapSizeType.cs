namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;

[GraphQLDescription("Supported map sizes")]
public enum MapSizeType
{
    [GraphQLDescription("None - was unable to parse")]
    None,

    [GraphQLDescription("256 players (largest supported)")]
    Ultra,

    [GraphQLDescription("128 players (second largest)")]
    Big,

    [GraphQLDescription("64 players")]
    Medium,

    [GraphQLDescription("32 players (smallest supported)")]
    Tiny
}