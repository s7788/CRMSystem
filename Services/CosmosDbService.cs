using Microsoft.Azure.Cosmos;
using CRMSystem.Models;
using System.Net;

namespace CRMSystem.Services
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        
        public CosmosDbService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var query = _container.GetItemQueryIterator<Customer>(
                new QueryDefinition("SELECT * FROM c WHERE c.partitionKey = 'customer'"));
            
            var customers = new List<Customer>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                customers.AddRange(response.ToList());
            }

            return customers.OrderBy(c => c.Name);
        }

        public async Task<Customer?> GetCustomerAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<Customer>(id, new PartitionKey("customer"));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            customer.PartitionKey = "customer";
            customer.CreatedDate = DateTime.UtcNow;
            customer.LastModified = DateTime.UtcNow;

            var response = await _container.CreateItemAsync(customer, new PartitionKey(customer.PartitionKey));
            return response.Resource;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            customer.LastModified = DateTime.UtcNow;
            var response = await _container.UpsertItemAsync(customer, new PartitionKey(customer.PartitionKey));
            return response.Resource;
        }

        public async Task DeleteCustomerAsync(string id)
        {
            await _container.DeleteItemAsync<Customer>(id, new PartitionKey("customer"));
        }

        public async Task<IEnumerable<Customer>> SearchCustomersAsync(string searchTerm)
        {
            var query = _container.GetItemQueryIterator<Customer>(
                new QueryDefinition("SELECT * FROM c WHERE c.partitionKey = 'customer' AND (CONTAINS(UPPER(c.name), @searchTerm) OR CONTAINS(UPPER(c.phone), @searchTerm) OR CONTAINS(UPPER(c.mobile), @searchTerm))")
                .WithParameter("@searchTerm", searchTerm.ToUpper()));

            var customers = new List<Customer>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                customers.AddRange(response.ToList());
            }

            return customers.OrderBy(c => c.Name);
        }
    }
}