using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.GraphQL.Filters;

public class CustomStringConventions : FilterConvention
{
    protected override void Configure(
        IFilterConventionDescriptor descriptor)
    {
        descriptor.AddDefaults();

        descriptor.Provider(
            new QueryableFilterProvider(x =>
                x.AddDefaultFieldHandlers()
                    .AddFieldHandler<QueryableStringInvariantContainsHandler>()));
    }
}