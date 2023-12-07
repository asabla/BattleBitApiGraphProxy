using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.GraphQL.Resolvers;

[ExtendObjectType(nameof(Query))]
public sealed class BattleBitResolvers
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    [GraphQLDescription("Fetches all BattleBit servers from public API")]
    public Task<IReadOnlyList<ServerInfo>> GetServers(
        BattleBitAPIService bService,
        CancellationToken cancellationToken)
        => bService.GetAllServersAsync(cancellationToken);
}