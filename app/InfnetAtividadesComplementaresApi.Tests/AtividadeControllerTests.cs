using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Amazon.Lambda.TestUtilities;


namespace InfnetAtividadesComplementaresApi.Tests
{
    public class AtividadeControllerTests
    {

        [Fact]
        public async Task ConsultaBasicaRetorna200()
        {
            var requestMock = MockFactory.GetApiGatewayRequestObject("/api/atividade/consulta", HttpMethod.Get);
            var context = new TestLambdaContext();
            
            var lambdaFunction = new LambdaEntryPoint();
            var response = await lambdaFunction.FunctionHandlerAsync(requestMock, context);

            Assert.Equal(200, response.StatusCode);
            Assert.True(response.MultiValueHeaders.ContainsKey("Content-Type"));
            Assert.Equal("application/json; charset=utf-8", response.MultiValueHeaders["Content-Type"][0]);
        }
    }
}
