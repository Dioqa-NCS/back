using FluentAssertions;
using System.Net;

namespace APITest.Controllers;
public class AdresseControllerTest : IntegrationTest
{
    public AdresseControllerTest(ApiWebApplicationFactory fixture) : base(fixture)
    {    }


    [Fact]
    public async Task GET_retrieves_weather_forecast()
    {

        var response = await _client.GetAsync("/weatherforecast");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
