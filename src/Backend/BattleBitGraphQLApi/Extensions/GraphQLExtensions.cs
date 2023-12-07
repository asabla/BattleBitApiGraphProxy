using BattleBitProxy.Backend.BattleBitGraphQLApi.GraphQL.Filters;
using BattleBitProxy.Backend.BattleBitGraphQLApi.Services;

using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
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
                .AllowIntrospection(builder.Environment.IsDevelopment())
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
                .AddReadOnlyFileSystemQueryStorage("./persisted_queries")
                .ModifyRequestOptions(opt =>
                    opt.OnlyAllowPersistedQueries = builder.Environment.IsProduction())
            .AddInMemoryQueryStorage()
            .AddGraphQLTypes()
            .AddFiltering<CustomStringConventions>()
                .AddConvention<IFilterConvention>(new FilterConventionExtension(
                    x => x.AddProviderExtension(new QueryableFilterProviderExtension(
                        p => p.AddFieldHandler<QueryableStringInvariantContainsHandler>()
                    ))
                ))
            .AddProjections()
            .AddSorting()
            .RegisterService<BattleBitAPIService>(ServiceKind.Resolver);

        return builder;
    }
}