using System.ComponentModel.DataAnnotations;

namespace BattleBitProxy.ServerExplorer;

public class FrontendOptions
{
    public const string Frontend = "Frontend";

    [Url]
    public string BackendUrl { get; set; } = null!;

    [Url]
    public string BackendWebsocketUrl { get; set; } = null!;
}