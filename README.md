# BattleBitAPI GraphQL Proxy

Just a GraphQL wrapper around BattleBits own REST API using [HotChocolate](https://chillicream.com/docs/hotchocolate/v13) Nuget [package](https://www.nuget.org/packages/HotChocolate/13.3.0-preview.9). Which let's us expose it as a GraphQL endpoint and adding sorting, filtering and skip/take functionality.

## Getting started

In order to run this project you'll need at least .Net 7.0.3xx SDK installed. Easiest way of installing it can be found at Microsofts own [page for .Net](https://dotnet.microsoft.com/en-us/download).

After that you'll have to download this repository. Either using Git or by downloading it as a ZIP-archive. Go to the root of the repository, where you'll see files such as this readme file and the solution file (.sln)

Navigate to this directory with your terminal of choice (bash, fish, cmd, powershell etc) and then run the following command:

**For Windows:**

```powershell
dotnet run --project .\src\Backend\BatleBitGraphQLApi
```

**For Linux:**

```bash
dotnet run --project ./src/Backend/BattleBitGraphQLApi
```

After that, navigate to the GraphQL client ([Banana Cake pop](https://chillicream.com/products/bananacakepop)), which you can find under [localhost:7113](https://localhost:7113/graphql/).

Now you're ready to start querying BattleBits API by typing in a GraphQL query. An example of a simple query which fetches all servers and displays their name looks like this:

```graphql
query exampleQuery {
  servers {
    totalCount
    items {
      name
    }
  }
}
```

More example queries can be found under the docs [directory](docs/example_queries/).
