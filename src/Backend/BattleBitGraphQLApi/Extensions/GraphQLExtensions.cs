using BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

using HotChocolate.Types.Pagination;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.Extensions;

internal static class GraphQLExtensions
{
    public static WebApplicationBuilder ConfigureGraphQLServer(
        this WebApplicationBuilder builder)
    {
        builder.Services
            .AddMemoryCache()       // Used by persisted queries pipeline
            .AddGraphQLServer()
                .InitializeOnStartup()
                .ModifyRequestOptions(opt =>
                {
                    opt.Complexity.Enable = true;
                    opt.Complexity.MaximumAllowed = 1500;
                })
                .SetPagingOptions(new PagingOptions
                {
                    DefaultPageSize = 10_000,
                    MaxPageSize = 10_000,
                    IncludeTotalCount = true,
                })
                .UseAutomaticPersistedQueryPipeline()
            .AddInMemoryQueryStorage()
            .AddGraphQLTypes()
            .AddFiltering()
            .AddProjections()
            .AddSorting()
            .RegisterService<BattleBitAPIService>(ServiceKind.Resolver);

        return builder;
    }
}