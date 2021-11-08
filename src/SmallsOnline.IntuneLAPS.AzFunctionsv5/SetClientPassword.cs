using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

using SmallsOnline.IntuneLAPS.AzFunctions.Services;
using SmallsOnline.IntuneLAPS.Lib.Helpers;
using SmallsOnline.IntuneLAPS.Lib.Models.Communication;

namespace SmallsOnline.IntuneLAPS.AzFunctions
{
    public class SetClientPassword
    {
        private readonly IKeyVaultService keyVaultService;
        public SetClientPassword(IKeyVaultService _keyVaultService)
        {
            keyVaultService = _keyVaultService;
        }
        [Function("SetClientPassword")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("SetClientPassword");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            string reqBody = req.ReadAsString();
            SetPasswordPost bodyData = JsonConverterHelper.ConvertFromJson<SetPasswordPost>(reqBody);
            keyVaultService.SecretClient.SetSecret(bodyData.ComputerName, bodyData.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");



            return response;
        }
    }
}
