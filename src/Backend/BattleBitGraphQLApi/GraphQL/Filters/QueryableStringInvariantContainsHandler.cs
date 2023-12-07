using System.Linq.Expressions;
using System.Reflection;

using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.GraphQL.Filters;

public class QueryableStringInvariantContainsHandler : QueryableStringOperationHandler
{
    private static readonly MethodInfo Contains =
        typeof(string).GetMethod(
            name: "IndexOf",
            types: new[] {
                typeof(string),
                typeof(StringComparison)
            }) ?? null!;

    public QueryableStringInvariantContainsHandler(InputParser inputParser)
        : base(inputParser) { }

    protected override int Operation => DefaultFilterOperations.Contains;

    public override Expression HandleOperation(
        QueryableFilterContext context,
        IFilterOperationField field,
        IValueNode value,
        object? parsedValue)
    {
        Expression property = context.GetInstance();

        return parsedValue is string str
            ? Expression.AndAlso(
                Expression.NotEqual(
                    left: property,
                    right: Expression.Constant(null, typeof(object))),
                Expression.NotEqual(
                    left: Expression.Call(
                        property,
                        Contains,
                        Expression.Constant(str),
                        Expression.Constant(StringComparison.OrdinalIgnoreCase)),
                    right: Expression.Constant(-1)))
                ?? null!
            : throw new InvalidOperationException();
    }
}