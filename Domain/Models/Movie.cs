using System.Text.Json.Serialization;

namespace SneakPeek.Models;

public class Movie
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("wait")]
    public string Wait { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public string Release_date { get; set; } = string.Empty;

    [JsonPropertyName("genre")]
    public string Genre { get; set; } = string.Empty;

    [JsonPropertyName("directors")]
    public List<string> Directors { get; set; } = new List<string>();

    [JsonPropertyName("rating")]
    public double Rating { get; set; }
}
