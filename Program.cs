using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Azure.Cosmos;
using CRMSystem;
using CRMSystem.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// 檢查是否使用離線模式
var useOfflineMode = builder.Configuration["UseOfflineMode"] ?? "true";

if (useOfflineMode.Equals("true", StringComparison.OrdinalIgnoreCase))
{
    // 使用模擬服務進行開發測試
    builder.Services.AddScoped<ICosmosDbService, MockCosmosDbService>();
}
else
{
    // Azure Cosmos DB 配置
    var cosmosEndpoint = builder.Configuration["CosmosDb:Endpoint"] ?? "https://localhost:8081";
    var cosmosKey = builder.Configuration["CosmosDb:Key"] ?? "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
    var databaseName = builder.Configuration["CosmosDb:DatabaseName"] ?? "CRMDatabase";
    var containerName = builder.Configuration["CosmosDb:ContainerName"] ?? "Customers";

    builder.Services.AddSingleton(sp =>
    {
        var cosmosClientOptions = new CosmosClientOptions
        {
            SerializerOptions = new CosmosSerializationOptions
            {
                PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
            }
        };
        return new CosmosClient(cosmosEndpoint, cosmosKey, cosmosClientOptions);
    });

    builder.Services.AddScoped<ICosmosDbService>(sp =>
    {
        var cosmosClient = sp.GetRequiredService<CosmosClient>();
        return new CosmosDbService(cosmosClient, databaseName, containerName);
    });
}

await builder.Build().RunAsync();
