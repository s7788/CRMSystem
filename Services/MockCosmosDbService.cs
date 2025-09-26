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

            customer1.VisitRecords.Add(new VisitRecord
            {
                VisitDate = DateTime.Today.AddDays(-7),
                Assignee = "呂歡",
                ConversationContent = "討論投資組合調整，客戶對科技股表現滿意",
                InvestmentAdjustments = "增加科技基金部位",
                FollowUpActions = "下周再次追蹤市場狀況"
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