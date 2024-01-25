namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBitAPIModels;

[Serializable]
public class BattleBitAPIServerInfo
{
    public string AntiCheat { get; set; } = null!;
    public string Build { get; set; } = null!;
    public string DayNight { get; set; } = null!;
    public string Gamemode { get; set; } = null!;
    public bool HasPassword { get; set; } = false;
    public int Hz { get; set; }
    public bool IsOfficial { get; set; } = false;
    public string Map { get; set; } = null!;
    public string MapSize { get; set; } = null!;
    public int MaxPlayers { get; set; }
    public string Name { get; set; } = null!;
    public int Players { get; set; }
    public int QueuePlayers { get; set; }
    public string Region { get; set; } = null!;

    public DateTime LastUpdated => DateTime.UtcNow;
}