using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Respawn;

namespace APITest;

abstract public class IntegrationTest : IClassFixture<ApiWebApplicationFactory>
{
    protected readonly ApiWebApplicationFactory _factory;
    protected readonly HttpClient _client;
    public IntegrationTest(ApiWebApplicationFactory fixture)
    {
        _factory = fixture;
        _client = _factory.CreateClient();

        var connection = _factory.Configuration.GetConnectionString("SQL");

        using var conn = new MySqlConnection(connection);
        conn.Open();

        var respawn = Respawner.CreateAsync(
           conn,
           new RespawnerOptions
           {
               WithReseed = true,
               DbAdapter = DbAdapter.MySql

           }).GetAwaiter().GetResult();

        respawn.ResetAsync(conn).Wait();
    }

}
