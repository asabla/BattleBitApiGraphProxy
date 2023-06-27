using System.Text.Json.Serialization;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBit;

[Serializable]
public class ServerInfo
{
    public string AntiCheat { get; set; } = null!;
    public AntiCheatType AntiCheatType
        => (AntiCheatType)Enum.Parse(typeof(AntiCheatType), AntiCheat);

    public string Build { get; set; } = null!;

    public string DayNight { get; set; } = null!;
    public DayNightType DayNightType
        => (DayNightType)Enum.Parse(typeof(DayNightType), DayNight);

    public string Gamemode { get; set; } = null!;
    public GameModeType GameModeType
        => (GameModeType)Enum.Parse(typeof(GameModeType), Gamemode);

    public bool HasPassword { get; set; } = false;
    public int Hz { get; set; }
    public bool IsOfficial { get; set; } = false;

    public string Map { get; set; } = null!;
    public MapType MapType
        => (MapType)Enum.Parse(typeof(MapType), Map);

    public string MapSize { get; set; } = null!;
    public MapSizeType MapSizeType
        => (MapSizeType)Enum.Parse(typeof(MapSizeType), MapSize);

    public int MaxPlayers { get; set; }
    public string Name { get; set; } = null!;
    public int Players { get; set; }
    public int QueuePlayers { get; set; }

    public string Region { get; set; } = null!;
    public RegionType RegionType
        => (RegionType)Enum.Parse(typeof(RegionType), Region);
}