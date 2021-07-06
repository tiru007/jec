using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Service.Function
{
    public static class GetCustomers
    {
        [FunctionName("GetCustomers")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestMessage req,
            [CosmosDB(
                databaseName: "customer",
                collectionName: "customer",
                ConnectionStringSetting = "CosmosDbConnectionString",
                SqlQuery = "SELECT * FROM c order by c._ts desc")]
                IEnumerable<Customer> customers,
            ILogger log)
        {
          return new OkObjectResult(customers);
        }
    }
}
