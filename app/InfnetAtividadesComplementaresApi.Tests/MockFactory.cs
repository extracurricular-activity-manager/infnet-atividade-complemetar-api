using System.IO;
using System.Net.Http;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

namespace InfnetAtividadesComplementaresApi.Tests
{
    public static class MockFactory
    {
        public static APIGatewayProxyRequest GetApiGatewayRequestObject(string requestPath, HttpMethod httpMethod)
        {
            var requestStr = File.ReadAllText("./SampleRequests/ApiGatewayMockObject.json");
            var mockRequest = JsonConvert.DeserializeObject<APIGatewayProxyRequest>(requestStr);
            var requestPathSlash = requestPath[0].Equals("/"[0]) ? requestPath : "/" + requestPath; 
            var requestPathNoSlash = requestPath[0].Equals("/"[0]) ? requestPath.Substring(1) : requestPath; 
            mockRequest.Path = requestPathSlash;
            mockRequest.PathParameters["proxy"] = requestPathNoSlash;
            mockRequest.HttpMethod = httpMethod.Method;
            mockRequest.RequestContext.HttpMethod = httpMethod.Method;
            return mockRequest;
        }
    }
}