using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRMSystem.Models
{
    public class InvestmentRecord
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "下單日期為必填項目")]
        [JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "幣別為必填項目")]
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonPropertyName("fundName")]
        public string FundName { get; set; } = string.Empty;

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("profitLoss")]
        public decimal ProfitLoss { get; set; }

        [JsonPropertyName("assetType")]
        public string AssetType { get; set; } = "基金"; // 基金、債券、股票、存款

        [JsonPropertyName("status")]
        public string Status { get; set; } = "持有中";

        [JsonPropertyName("notes")]
        public string Notes { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}