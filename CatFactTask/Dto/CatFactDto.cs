using System.Text.Json.Serialization;

namespace CatFactTask.Dto;

public class CatFactDto
{
    [JsonPropertyName("fact")]
    public string Fact { get; init; } = string.Empty;
    [JsonPropertyName("length")]
    public int Length { get; init; }
}