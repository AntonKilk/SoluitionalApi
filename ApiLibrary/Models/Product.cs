using Newtonsoft.Json;

namespace ApiLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public decimal Price { get; set; }

        [JsonProperty("price")]
        public string PriceFormatted => Price.ToString("0.##");
    }

}
