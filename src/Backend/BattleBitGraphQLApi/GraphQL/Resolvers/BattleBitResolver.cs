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

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<TopClanObject>> GetTopClans(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetTopClans(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostXP(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostXPAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostHeals(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostHealsAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostKills(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostKillsAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostRevives(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostRevivesAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostRoadKills(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostRoadKillsAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostLongestKills(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostLongestKillAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostVehicleRepairs(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostVehicleRepairsAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostVehiclesDestroyed(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostVehiclesDestroyedAsync(cancellationToken);

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public Task<IReadOnlyList<StatisticsObject>> GetMostObjectivesCompleted(
            BattleBitAPIService bService,
            CancellationToken cancellationToken)
        => bService.GetMostObjectivesCompletedAsync(cancellationToken);
}