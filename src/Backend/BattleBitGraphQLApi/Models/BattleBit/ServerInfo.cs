using System.ComponentModel;
using System;
namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBit;

public class ServerInfo
{
    public string Name { get; set; } = null!;
    public string Map { get; set; } = null!;
    public string MapSize { get; set; } = null!;
    public string Region { get; set; } = null!;
    public int Players { get; set; }
    public int QueuePlayers { get; set; }
    public int MaxPlayers { get; set; }
    public int Hz { get; set; }
    public string DayNight { get; set; } = null!;
    public bool IsOfficial { get; set; } = false;
    public bool HasPassword { get; set; } = false;
    public string AntiCheat { get; set; } = null!;
    public string Build { get; set; } = null!;
}