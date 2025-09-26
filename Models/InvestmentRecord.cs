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

        [JsonPropertyName("fundCode")]
        public string FundCode { get; set; } = string.Empty; // 基金代碼

        [Required(ErrorMessage = "投資金額為必填項目")]
        [Range(0.01, double.MaxValue, ErrorMessage = "投資金額必須大於0")]
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("units")]
        public decimal Units { get; set; } // 持有單位數

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; } // 單位淨值

        [JsonPropertyName("currentValue")]
        public decimal CurrentValue { get; set; } // 目前市值

        [JsonPropertyName("profitLoss")]
        public decimal ProfitLoss { get; set; } // 損益金額

        [JsonPropertyName("profitLossPercentage")]
        public decimal ProfitLossPercentage { get; set; } // 損益百分比

        [JsonPropertyName("assetType")]
        public string AssetType { get; set; } = "基金"; // 基金、債券、股票、存款、保險

        [JsonPropertyName("riskLevel")]
        public string RiskLevel { get; set; } = "中等"; // 低風險、中等、高風險

        [JsonPropertyName("status")]
        public string Status { get; set; } = "持有中";

        [JsonPropertyName("purchaseType")]
        public string PurchaseType { get; set; } = "單筆"; // 單筆、定期定額

        [JsonPropertyName("monthlyAmount")]
        public decimal MonthlyAmount { get; set; } // 定期定額月扣金額

        [JsonPropertyName("sellDate")]
        public DateTime? SellDate { get; set; } // 賣出日期

        [JsonPropertyName("sellAmount")]
        public decimal SellAmount { get; set; } // 賣出金額

        [JsonPropertyName("commission")]
        public decimal Commission { get; set; } // 手續費

        [JsonPropertyName("dividend")]
        public decimal Dividend { get; set; } // 配息金額

        [JsonPropertyName("notes")]
        public string Notes { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("lastModified")]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        // 計算屬性
        [JsonIgnore]
        public decimal TotalReturn => ProfitLoss + Dividend; // 總報酬

        [JsonIgnore]
        public decimal TotalReturnPercentage => Amount > 0 ? (TotalReturn / Amount) * 100 : 0; // 總報酬率

        [JsonIgnore]
        public string StatusColor => Status switch
        {
            "持有中" => "success",
            "已贖回" => "secondary",
            "已停損" => "danger",
            "已獲利了結" => "primary",
            _ => "info"
        };

        [JsonIgnore]
        public string ProfitLossColor => ProfitLoss >= 0 ? "text-success" : "text-danger";
    }
}