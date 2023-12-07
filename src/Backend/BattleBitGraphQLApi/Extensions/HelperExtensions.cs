namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

public static class HelperExtensions
{
    public static TEnum CastTo<TEnum>(this string value, TEnum defaultValue)
        where TEnum : struct, Enum
        => Enum.TryParse(value, out TEnum parsedValue)
            && Enum.IsDefined(typeof(TEnum), parsedValue)
                ? parsedValue
                : defaultValue;
}