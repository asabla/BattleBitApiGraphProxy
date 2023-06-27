using BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

using HotChocolate.Types.Pagination;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

internal static class GraphQLExtensions
{
    public static WebApplicationBuilder ConfigureGraphQLServer(
        this WebApplicationBuilder builder)
    {
        builder.Services
            .AddGraphQLServer()
                .InitializeOnStartup()
                .ModifyRequestOptions(opt =>
                {
                    opt.Complexity.Enable = true;
                    opt.Complexity.MaximumAllowed = 1500;
                })
                .SetPagingOptions(new PagingOptions
                {
                    MaxPageSize = 10_000,
                    IncludeTotalCount = true
                })
            .AddTypes()
            .AddFiltering()
            .AddProjections()
            .AddSorting()
            .RegisterService<BattleBitAPIService>(ServiceKind.Resolver);

        return builder;
    }
}