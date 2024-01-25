namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;

[GraphQLDescription("Supported time cycles")]
public enum DayNightType
{
    [GraphQLDescription("None - was unable to parse value")]
    None,

    [GraphQLDescription("Day")]
    Day,

    [GraphQLDescription("Night")]
    Night
}