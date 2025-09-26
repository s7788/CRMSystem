using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRMSystem.Models
{
    public class VisitRecord
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "拜訪日期為必填項目")]
        [JsonPropertyName("visitDate")]
        public DateTime VisitDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "負責人為必填項目")]
        [JsonPropertyName("assignee")]
        public string Assignee { get; set; } = string.Empty;

        [JsonPropertyName("conversationContent")]
        public string ConversationContent { get; set; } = string.Empty;

        [JsonPropertyName("investmentAdjustments")]
        public string InvestmentAdjustments { get; set; } = string.Empty;

        [JsonPropertyName("followUpActions")]
        public string FollowUpActions { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("lastModified")]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
    }
}