using BattleBitProxy.Backend.BattleBitGraphQLApi.Models.BattleBit;

namespace BattleBitProxy.Backend.BattleBitGraphQLApi.GraphQL.TypeConfigurations;

public class ServerInfoType : ObjectType<ServerInfo>
{
    protected override void Configure(IObjectTypeDescriptor<ServerInfo> descriptor)
    {
        descriptor
            .Description("""
                All current information listed by each hosted and online server from
                BattleBits own public API
            """);

        descriptor
            .Field(x => x.AntiCheat)
            .Description("Which AntiCheat system is in use on server");

        descriptor
            .Field(x => x.Build)
            .Description("Which current build is in use on the server");

        descriptor
            .Field(x => x.DayNight)
            .Description("Displays if current map is running day or night mode");

        descriptor
            .Field(x => x.HasPassword)
            .Description("If server has a password for joining or not");

        descriptor
            .Field(x => x.Hz)
            .Description("Current tickrate for the server");

        descriptor
            .Field(x => x.IsOfficial)
            .Description("If current server is runnign official settings or not");

        descriptor
            .Field(x => x.Map)
            .Description("Which current map is running on the server");

        descriptor
            .Field(x => x.MapSize)
            .Description("String representation of maximum number of players");

        descriptor
            .Field(x => x.MaxPlayers)
            .Description("Maximum amount of players supported by current server");

        descriptor
            .Field(x => x.Players)
            .Description("Current number of playerse on the server");

        descriptor
            .Field(x => x.QueuePlayers)
            .Description("Number of players in queue for joining the server");

        descriptor
            .Field(x => x.Region)
            .Description("Which region current server is hosted in");
    }
}