namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Models.GraphQLModels.Types;

[GraphQLDescription("Available maps")]
public enum MapType
{
    [GraphQLDescription("None - was unable to parse value")]
    None,

    [GraphQLDescription(nameof(MapType.Azagor))]
    Azagor,

    [GraphQLDescription(nameof(MapType.Dustydew))]
    Dustydew,

    [GraphQLDescription(nameof(MapType.Basra))]
    Basra,

    [GraphQLDescription(nameof(MapType.Construction))]
    Construction,

    [GraphQLDescription(nameof(MapType.District))]
    District,

    [GraphQLDescription(nameof(MapType.Eduardovo))]
    Eduardovo,

    [GraphQLDescription(nameof(MapType.Frugis))]
    Frugis,

    [GraphQLDescription(nameof(MapType.Isle))]
    Isle,

    [GraphQLDescription(nameof(MapType.Lonovo))]
    Lonovo,

    [GraphQLDescription(nameof(MapType.MultuIslands))]
    MultuIslands,

    [GraphQLDescription(nameof(MapType.Namak))]
    Namak,

    [GraphQLDescription(nameof(MapType.OilDunes))]
    OilDunes,

    [GraphQLDescription(nameof(MapType.Range))]
    Range,

    [GraphQLDescription(nameof(MapType.River))]
    River,

    [GraphQLDescription(nameof(MapType.SandySunset))]
    SandySunset,

    [GraphQLDescription(nameof(MapType.Salhan))]
    Salhan,

    [GraphQLDescription(nameof(MapType.TensaTown))]
    TensaTown,

    [GraphQLDescription(nameof(MapType.Valley))]
    Valley,

    [GraphQLDescription(nameof(MapType.Wakistan))]
    Wakistan,

    [GraphQLDescription(nameof(MapType.WineParadise))]
    WineParadise
}