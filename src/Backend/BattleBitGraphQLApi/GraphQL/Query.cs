namespace BattleBitProxy.Backend.BattleBitGraphQLApi.GraphQL;

[QueryType]
[GraphQLDescription("All supported queries")]
public class Query
{
    public Book GetBook() =>
        new()
        {
            Title = "Some example Book title",
            Author = new()
            {
                Name = "Some example Author Name"
            }
        };
}

public record Book
{
    public string Title { get; set; } = null!;
    public Author Author { get; set; } = null!;
}

public record Author
{
    public string Name { get; set; } = null!;
}