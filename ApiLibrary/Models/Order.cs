using System.Text.Json.Serialization;

namespace ApiLibrary.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        New,
        Paid,
        Unpaid
    }

    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public OrderStatus Status { get; set; } = OrderStatus.New;
        public List<Product> Products { get; set; } = new List<Product>();
        public OrderAmount Amount { get; set; } = new OrderAmount();
    }

    public class OrderAmount
    {
        [JsonIgnore]
        public decimal Discount { get; set; } = 0.00M;

        [JsonIgnore]
        public decimal Paid { get; set; } = 0.00M;

        [JsonIgnore]
        public decimal Returns { get; set; } = 0.00M;

        [JsonIgnore]
        public decimal Total { get; set; } = 0.00M;

        [JsonPropertyName("discount")]
        public string DiscountFormatted => Discount.ToString("0.00");

        [JsonPropertyName("paid")]
        public string PaidFormatted => Paid.ToString("0.00");

        [JsonPropertyName("returns")]
        public string ReturnsFormatted => Returns.ToString("0.00");

        [JsonPropertyName("total")]
        public string TotalFormatted => Total.ToString("0.00");
    }

}
