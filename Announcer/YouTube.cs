using Microsoft.AspNetCore.Mvc;
using System.Xml;

public class YouTubeController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public YouTubeController(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    [HttpGet("/")]
    public IActionResult Register(
        [FromQuery(Name = "hub.challenge")] string challenge,
        [FromQuery(Name = "hub.topic")] string topic)
    {
        const string requiredTopic = "https://www.youtube.com/xml/feeds/videos.xml?channel_id=UC5QGWHAp6w_NbgPIl10kqnA";
        if (topic != requiredTopic) return BadRequest(new { Message = "Topic isn't what it should be." });

        return Ok(challenge);
    }

    [HttpPost("/")]
    public async Task<IActionResult> Announce([FromBody] XmlDocument body)
    {
        string? channelId = body["feed"]?["entry"]?["yt:channelId"]?.ToString();
        if (channelId is null) return BadRequest(new { Message = "yt:channelId doesn't exist" });

        const string requiredChannelId = "UC5QGWHAp6w_NbgPIl10kqnA";
        if (channelId != requiredChannelId) return BadRequest(new { Message = "yt:channelId doesn't equal the correct channel id." });

        return Ok();
    }
}