using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.Settings;

using FluentValidation;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

internal class ApiSettingsValidator : AbstractValidator<ApiSettings>
{
    public ApiSettingsValidator()
    {
        // TODO: Add properties to be validated here
    }
}