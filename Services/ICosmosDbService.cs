using CRMSystem.Models;

namespace CRMSystem.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer?> GetCustomerAsync(string id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(string id);
        Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm);
    }
}