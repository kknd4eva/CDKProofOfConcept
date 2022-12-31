using Amazon;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using AWS.Lambda.Powertools.Logging;
using Amazon.Lambda.Serialization.SystemTextJson;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace APILambda;

public class Function
{
    [Logging(LogEvent = true)]
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest proxyRequest, ILambdaContext context)
    {
        Logger.LogInformation($"Api endpoint invoked.");

        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = "Hello from a CDK deployed application..",
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }

    [Logging(LogEvent = true)]
    public async Task<APIGatewayProxyResponse> FunctionHandlerGoodbye(APIGatewayProxyRequest proxyRequest, ILambdaContext context)
    {
        Logger.LogInformation($"Api endpoint invoked.");

        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = "Goodbye from a CDK deployed application..",
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}
