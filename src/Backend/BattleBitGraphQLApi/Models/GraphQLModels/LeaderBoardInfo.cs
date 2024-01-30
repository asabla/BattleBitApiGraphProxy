namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels;

public class LeaderBoardInfo
{
    public IEnumerable<TopClanObject> TopClans { get; set; }
        = Enumerable.Empty<TopClanObject>();

    public IEnumerable<StatisticsObject> MostXP { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostHeals { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostRevives { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostVehiclesDestroyed { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostVehicleRepairs { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostRoadKills { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostLongestKill { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostObjectivesComplete { get; set; }
        = Enumerable.Empty<StatisticsObject>();

    public IEnumerable<StatisticsObject> MostKills { get; set; }
        = Enumerable.Empty<StatisticsObject>();
}

public class TopClanObject
{
    public string ClanName { get; set; } = null!;
    public string Tag { get; set; } = null!;
    public int XP { get; set; }
    public int MaxPlayers { get; set; }
    public int Position { get; set; }
}

public class StatisticsObject
{
    public string PlayerName { get; set; } = null!;
    public int Value { get; set; }
    public int Position { get; set; }
}