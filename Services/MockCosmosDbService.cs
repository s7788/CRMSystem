using CRMSystem.Models;

namespace CRMSystem.Services
{
    public class MockCosmosDbService : ICosmosDbService
    {
        private readonly List<Customer> _customers = new();

        public MockCosmosDbService()
        {
            // 預設測試資料
            SeedData();
        }

        private void SeedData()
        {
            var customer1 = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                Name = "王小明",
                Gender = "男",
                Phone = "02-12345678",
                Mobile = "0912-345678",
                Address = "台北市信義區信義路123號",
                Occupation = "工程師",
                CustomerSource = "朋友",
                AssignedTo = "呂歡",
                BirthDate = new DateTime(1985, 5, 15),
                ChildrenInfo = "兒子3歲",
                Notes = "喜歡投資科技股，平日晚上7點後較容易聯絡"
            };

            customer1.InvestmentRecords.AddRange(new[]
            {
                new InvestmentRecord
                {
                    OrderDate = DateTime.Today.AddDays(-30),
                    Currency = "TWD",
                    FundName = "富蘭克林科技基金",
                    FundCode = "TW0001",
                    Amount = 100000,
                    Units = 1000,
                    UnitPrice = 105.5m,
                    CurrentValue = 105500,
                    ProfitLoss = 5500,
                    ProfitLossPercentage = 5.5m,
                    AssetType = "基金",
                    RiskLevel = "高風險",
                    Status = "持有中",
                    PurchaseType = "單筆",
                    Dividend = 500,
                    Commission = 300,
                    Notes = "看好科技股未來發展"
                },
                new InvestmentRecord
                {
                    OrderDate = DateTime.Today.AddDays(-60),
                    Currency = "USD",
                    FundName = "美國標普500指數基金",
                    FundCode = "US500",
                    Amount = 50000,
                    Units = 500,
                    UnitPrice = 98.0m,
                    CurrentValue = 49000,
                    ProfitLoss = -1000,
                    ProfitLossPercentage = -2.0m,
                    AssetType = "基金",
                    RiskLevel = "中等",
                    Status = "持有中",
                    PurchaseType = "定期定額",
                    MonthlyAmount = 10000,
                    Dividend = 200,
                    Commission = 150,
                    Notes = "長期投資美股市場"
                }
            });

            customer1.VisitRecords.AddRange(new[]
            {
                new VisitRecord
                {
                    VisitDate = DateTime.Today.AddDays(-7),
                    VisitTime = "14:30",
                    Assignee = "呂歡",
                    VisitType = "面談",
                    VisitLocation = "客戶家中",
                    VisitPurpose = "定期關懷及投資檢視",
                    CustomerMood = "滿意",
                    ConversationContent = "討論投資組合調整，客戶對科技股表現滿意，詢問是否需要增加部位。客戶提到最近工作穩定，有額外資金可投資。",
                    CustomerConcerns = "擔心市場波動，希望了解停損策略",
                    MarketDiscussion = "討論科技股前景，AI相關產業發展趨勢",
                    InvestmentAdjustments = "建議增加科技基金部位至30%",
                    ProductIntroduced = "AI科技基金、ESG永續基金",
                    CustomerFeedback = "對服務很滿意，希望持續定期追蹤",
                    FollowUpActions = "下周再次追蹤市場狀況，準備AI基金相關資料",
                    FollowUpDate = DateTime.Today.AddDays(7),
                    FollowUpCompleted = false,
                    VisitDuration = 60,
                    VisitRating = 5,
                    NextContactSuggestion = "每月第二週電話追蹤",
                    IsHotLead = true,
                    LeadScore = 85,
                    Tags = new List<string> { "高淨值", "科技股偏好", "定期客戶" }
                },
                new VisitRecord
                {
                    VisitDate = DateTime.Today.AddDays(-30),
                    VisitTime = "10:00",
                    Assignee = "呂歡",
                    VisitType = "電話",
                    VisitPurpose = "投資組合檢視",
                    CustomerMood = "中性",
                    ConversationContent = "電話確認投資狀況，客戶表示滿意目前配置",
                    FollowUpActions = "安排下次面談時間",
                    FollowUpDate = DateTime.Today.AddDays(-7),
                    FollowUpCompleted = true,
                    VisitDuration = 20,
                    VisitRating = 4,
                    LeadScore = 80,
                    Tags = new List<string> { "電話追蹤" }
                }
            });

            var customer2 = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                Name = "李美華",
                Gender = "女",
                Phone = "02-87654321",
                Mobile = "0987-654321",
                Address = "台北市大安區忠孝東路456號",
                Occupation = "醫師",
                CustomerSource = "銀行",
                AssignedTo = "孔韻昇",
                BirthDate = new DateTime(1978, 10, 22),
                ChildrenInfo = "女兒8歲、兒子5歲",
                Notes = "偏好穩健投資，週末較容易聯絡"
            };

            customer2.InvestmentRecords.AddRange(new[]
            {
                new InvestmentRecord
                {
                    OrderDate = DateTime.Today.AddDays(-45),
                    Currency = "TWD",
                    FundName = "台灣高股息基金",
                    FundCode = "TW0002",
                    Amount = 80000,
                    Units = 800,
                    UnitPrice = 102.5m,
                    CurrentValue = 82000,
                    ProfitLoss = 2000,
                    ProfitLossPercentage = 2.5m,
                    AssetType = "基金",
                    RiskLevel = "中等",
                    Status = "持有中",
                    PurchaseType = "單筆",
                    Dividend = 1200,
                    Commission = 200,
                    Notes = "穩健收息型投資"
                },
                new InvestmentRecord
                {
                    OrderDate = DateTime.Today.AddDays(-90),
                    Currency = "USD",
                    FundName = "美國政府債券基金",
                    FundCode = "USGOV",
                    Amount = 30000,
                    Units = 300,
                    UnitPrice = 101.0m,
                    CurrentValue = 30300,
                    ProfitLoss = 300,
                    ProfitLossPercentage = 1.0m,
                    AssetType = "債券",
                    RiskLevel = "低風險",
                    Status = "持有中",
                    PurchaseType = "單筆",
                    SellDate = DateTime.Today.AddDays(-10),
                    SellAmount = 30500,
                    Dividend = 800,
                    Commission = 100,
                    Notes = "保守投資組合"
                }
            });

            customer2.VisitRecords.AddRange(new[]
            {
                new VisitRecord
                {
                    VisitDate = DateTime.Today.AddDays(-5),
                    VisitTime = "19:00",
                    Assignee = "孔韻昇",
                    VisitType = "視訊",
                    VisitLocation = "線上會議",
                    VisitPurpose = "季度投資檢視",
                    CustomerMood = "滿意",
                    ConversationContent = "討論季度投資績效，客戶滿意債券基金的穩定收益，詢問是否有其他保守型投資選項。",
                    CustomerConcerns = "希望降低投資風險，確保資金安全",
                    MarketDiscussion = "討論債市走勢，利率政策影響",
                    InvestmentAdjustments = "建議增加政府債券比重",
                    ProductIntroduced = "短期債券基金、保本型商品",
                    CustomerFeedback = "讚賞風險控制得當，希望維持保守策略",
                    FollowUpActions = "提供保本型商品資料，安排下次季度檢視",
                    FollowUpDate = DateTime.Today.AddDays(90),
                    FollowUpCompleted = false,
                    VisitDuration = 45,
                    VisitRating = 4,
                    NextContactSuggestion = "季度檢視，週末時間較方便",
                    IsHotLead = false,
                    LeadScore = 70,
                    Tags = new List<string> { "保守型", "醫師", "季度檢視" }
                },
                new VisitRecord
                {
                    VisitDate = DateTime.Today.AddDays(-95),
                    VisitTime = "15:00",
                    Assignee = "孔韻昇",
                    VisitType = "面談",
                    VisitLocation = "診所",
                    VisitPurpose = "初次投資諮詢",
                    CustomerMood = "中性",
                    ConversationContent = "了解客戶投資需求，風險承受度評估",
                    FollowUpActions = "準備投資建議書",
                    FollowUpDate = DateTime.Today.AddDays(-80),
                    FollowUpCompleted = true,
                    VisitDuration = 90,
                    VisitRating = 4,
                    LeadScore = 65,
                    Tags = new List<string> { "新客戶", "風險評估" }
                }
            });

            _customers.AddRange(new[] { customer1, customer2 });
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(_customers.AsEnumerable());
        }

        public Task<Customer?> GetCustomerAsync(string id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }

        public Task<Customer> CreateCustomerAsync(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            customer.PartitionKey = "customer";
            customer.CreatedDate = DateTime.UtcNow;
            customer.LastModified = DateTime.UtcNow;
            
            _customers.Add(customer);
            return Task.FromResult(customer);
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                var index = _customers.IndexOf(existingCustomer);
                customer.LastModified = DateTime.UtcNow;
                _customers[index] = customer;
            }
            return Task.FromResult(customer);
        }

        public Task DeleteCustomerAsync(string id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
        {
            var results = _customers.Where(c => 
                c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.Phone.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                c.Mobile.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .AsEnumerable();
            
            return Task.FromResult(results);
        }
    }
}