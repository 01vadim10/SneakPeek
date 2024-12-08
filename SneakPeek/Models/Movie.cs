using System.Text.Json.Serialization;

namespace SneakPeek.Models;

public class Movie
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("wait")]
    public string Wait { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("release_date")]
    public string Release_date { get; set; }

    [JsonPropertyName("genre")]
    public string Genre { get; set; }

    [JsonPropertyName("director")]
    public List<string> Director { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }
}
