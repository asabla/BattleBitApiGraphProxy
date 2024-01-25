namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBitAPIModels;

public class BattleBitAPILeaderBoardInfo
{
    public IEnumerable<TopClanAPIObject> TopClans { get; set; }
        = Enumerable.Empty<TopClanAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostXP { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostHeals { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostRevives { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostVehiclesDestroyed { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostVehicleRepairs { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostRoadKills { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostLongestKill { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostObjectivesComplete { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();

    public IEnumerable<StatisticsAPIObject> MostKills { get; set; }
        = Enumerable.Empty<StatisticsAPIObject>();
}

public class StatisticsAPIObject
{
    public string Name { get; set; } = null!;
    public string Value { get; set; } = null!;
}

public class TopClanAPIObject
{
    public string Clan { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public string XP { get; set; } = null!;
    public string MaxPlayers { get; set; } = null!;
}