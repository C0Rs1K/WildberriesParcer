using System.Text.Json.Serialization;

namespace WBSearcher.Models
{
    public class Card
    {
        [JsonPropertyName("name")]
        public string Title { get; set; } = null!;
        [JsonPropertyName("brand")]
        public string Brand { get; set; } = null!;
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("feedbacks")]
        public int Feddbacks { get; set; }
        [JsonPropertyName("priceU")]
        public int Price { get; set; }

    }
}
