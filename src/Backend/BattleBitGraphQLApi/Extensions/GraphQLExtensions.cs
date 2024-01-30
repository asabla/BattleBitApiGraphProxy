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
                // Re-enable if/when there is a frontend project again
                // .AllowIntrospection(builder.Environment.IsDevelopment())
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
                // Remnant from frontend project, still relevant
                // .AddReadOnlyFileSystemQueryStorage("./persisted_queries")
                // .ModifyRequestOptions(opt =>
                //     opt.OnlyAllowPersistedQueries = builder.Environment.IsProduction())
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
            .RegisterService<BattleBitAPIService>(ServiceKind.Resolver)
            .UseInstrumentation()
            .UseExceptions()
            .UseDocumentCache()
            .UseDocumentParser()
            .UseDocumentValidation()
            .UseOperationCache()
            .UseOperationComplexityAnalyzer()
            .UseOperationResolver()
            .UseOperationVariableCoercion()
            .UseOperationExecution();

        return builder;
    }
}