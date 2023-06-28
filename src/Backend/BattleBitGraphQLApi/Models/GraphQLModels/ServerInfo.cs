using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels;

[GraphQLDescription("""
    All current information listed by each hosted and online server from
    BattleBits own public API
""")]
public class ServerInfo
{
    [GraphQLDescription("Which AntiCheat system is in use on server")]
    public AntiCheatType AntiCheat { get; set; }

    [GraphQLDescription("Which current build is in use on the server")]
    public string Build { get; set; } = null!;

    [GraphQLDescription("Displays if current map is running day or night mode")]
    public DayNightType DayNight { get; set; }

    [GraphQLDescription("Current running game mode on the server")]
    public GameModeType GameMode { get; set; }

    [GraphQLDescription("If server has a password is password protected or not")]
    public bool HasPassword { get; set; }

    [GraphQLDescription("Current tickrate for server")]
    public int Hz { get; set; }

    [GraphQLDescription("If server is running official settings or not")]
    public bool IsOfficial { get; set; }

    [GraphQLDescription("Which current map is running on the server")]
    public MapType Map { get; set; }

    [GraphQLDescription("String representation of maximum number of players")]
    public MapSizeType MapSize { get; set; }

    [GraphQLDescription("Maximum amount of players supported by current server")]
    public int MaxPlayers { get; set; }

    [GraphQLDescription("Current name for server")]
    public string Name { get; set; } = null!;

    [GraphQLDescription("Current number of players on server")]
    public int Players { get; set; }

    [GraphQLDescription("Number of players in queue for joining")]
    public int QueuePlayers { get; set; }

    [GraphQLDescription("Which region current server is hosted in")]
    public RegionType Region { get; set; }
}