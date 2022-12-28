using Microsoft.AspNetCore.Mvc;

public class YouTubeController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public YouTubeController(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    [HttpGet("/")]
    public IActionResult Register(
        [FromQuery(Name = "hub.challenge")] string? challenge)
    {
        if (challenge is not null)
        {
            return Ok(challenge);
        }
        return Ok();
    }

    [HttpPost("/")]
    public async Task<IActionResult> Announce()
    {
        await Task.Delay(0);
        return Ok();
    }
}