using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Service.Function
{
    public static class GetDevice
    {
        [FunctionName("GetCustomer")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{mobilenumber}/{id}")] HttpRequest req,
            [CosmosDB(
                databaseName: "customer",
                collectionName: "customer",
                ConnectionStringSetting = "CosmosDbConnectionString",
                PartitionKey ="{mobilenumber}",
                Id = "{id}")] Customer customer,
            ILogger log)
        {
             if (customer is null)
            {
                log.LogInformation($"Device not found");
                return new NotFoundResult();
            }
            return new OkObjectResult(customer);
        }
    }
}
