using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRMSystem.Models
{
    public class Customer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("partitionKey")]
        public string PartitionKey { get; set; } = "customer";

        [Required(ErrorMessage = "姓名為必填項目")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonPropertyName("birthDate")]
        public DateTime? BirthDate { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("mobile")]
        public string Mobile { get; set; } = string.Empty;

        [JsonPropertyName("childrenInfo")]
        public string ChildrenInfo { get; set; } = string.Empty;

        [JsonPropertyName("occupation")]
        public string Occupation { get; set; } = string.Empty;

        [JsonPropertyName("customerSource")]
        public string CustomerSource { get; set; } = string.Empty;

        [JsonPropertyName("assignedTo")]
        public string AssignedTo { get; set; } = string.Empty;

        [JsonPropertyName("notes")]
        public string Notes { get; set; } = string.Empty;

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("lastModified")]
        public DateTime LastModified { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("investmentRecords")]
        public List<InvestmentRecord> InvestmentRecords { get; set; } = new List<InvestmentRecord>();

        [JsonPropertyName("visitRecords")]
        public List<VisitRecord> VisitRecords { get; set; } = new List<VisitRecord>();
    }
}