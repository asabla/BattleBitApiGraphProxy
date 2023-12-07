namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;

[GraphQLDescription("Supported AntiCheat systems")]
public enum AntiCheatType
{
    [GraphQLDescription("No detected Anti system is active")]
    None,

    [GraphQLDescription("Easy AntiCheat")]
    EAC
}