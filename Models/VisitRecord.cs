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

        [JsonPropertyName("visitTime")]
        public string VisitTime { get; set; } = "14:00"; // 時間字串格式

        [Required(ErrorMessage = "負責人為必填項目")]
        [JsonPropertyName("assignee")]
        public string Assignee { get; set; } = string.Empty;

        [JsonPropertyName("visitType")]
        public string VisitType { get; set; } = "面談"; // 面談、電話、視訊、簡訊、EMAIL

        [JsonPropertyName("visitLocation")]
        public string VisitLocation { get; set; } = string.Empty; // 客戶家中、辦公室、咖啡廳等

        [JsonPropertyName("visitPurpose")]
        public string VisitPurpose { get; set; } = string.Empty; // 定期關懷、投資諮詢、產品介紹等

        [JsonPropertyName("customerMood")]
        public string CustomerMood { get; set; } = "中性"; // 滿意、中性、不滿、抱怨

        [JsonPropertyName("conversationContent")]
        public string ConversationContent { get; set; } = string.Empty;

        [JsonPropertyName("customerConcerns")]
        public string CustomerConcerns { get; set; } = string.Empty; // 客戶關注點

        [JsonPropertyName("marketDiscussion")]
        public string MarketDiscussion { get; set; } = string.Empty; // 市場討論內容

        [JsonPropertyName("investmentAdjustments")]
        public string InvestmentAdjustments { get; set; } = string.Empty;

        [JsonPropertyName("productIntroduced")]
        public string ProductIntroduced { get; set; } = string.Empty; // 介紹的產品

        [JsonPropertyName("customerFeedback")]
        public string CustomerFeedback { get; set; } = string.Empty; // 客戶回饋

        [JsonPropertyName("followUpActions")]
        public string FollowUpActions { get; set; } = string.Empty;

        [JsonPropertyName("followUpDate")]
        public DateTime? FollowUpDate { get; set; } // 預計追蹤日期

        [JsonPropertyName("followUpCompleted")]
        public bool FollowUpCompleted { get; set; } = false; // 追蹤是否完成

        [JsonPropertyName("visitDuration")]
        public int VisitDuration { get; set; } // 拜訪時長（分鐘）

        [JsonPropertyName("visitRating")]
        public int VisitRating { get; set; } = 3; // 拜訪效果評分 1-5

        [JsonPropertyName("nextContactSuggestion")]
        public string NextContactSuggestion { get; set; } = string.Empty; // 下次聯絡建議

        [JsonPropertyName("attachments")]
        public List<string> Attachments { get; set; } = new List<string>(); // 附件檔案名稱

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string>(); // 標籤

        [JsonPropertyName("isHotLead")]
        public bool IsHotLead { get; set; } = false; // 是否為熱門客戶

        [JsonPropertyName("leadScore")]
        public int LeadScore { get; set; } = 0; // 客戶評分 0-100

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("lastModified")]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        // 計算屬性
        [JsonIgnore]
        public string VisitTypeIcon => VisitType switch
        {
            "面談" => "bi-person-check",
            "電話" => "bi-telephone",
            "視訊" => "bi-camera-video",
            "簡訊" => "bi-chat-text",
            "EMAIL" => "bi-envelope",
            _ => "bi-chat-dots"
        };

        [JsonIgnore]
        public string MoodColor => CustomerMood switch
        {
            "滿意" => "success",
            "中性" => "secondary",
            "不滿" => "warning",
            "抱怨" => "danger",
            _ => "info"
        };

        [JsonIgnore]
        public string RatingStars => new string('★', VisitRating) + new string('☆', 5 - VisitRating);

        [JsonIgnore]
        public bool IsOverdue => FollowUpDate.HasValue && 
                                 FollowUpDate.Value < DateTime.Today && 
                                 !FollowUpCompleted;

        [JsonIgnore]
        public string FollowUpStatus => FollowUpCompleted ? "已完成" : 
                                       IsOverdue ? "逾期" : 
                                       FollowUpDate.HasValue ? "待處理" : "無追蹤";

        [JsonIgnore]
        public string FollowUpStatusColor => FollowUpCompleted ? "success" : 
                                            IsOverdue ? "danger" : 
                                            FollowUpDate.HasValue ? "warning" : "secondary";
    }
}