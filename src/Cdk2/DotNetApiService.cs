using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;
using Constructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdk2
{
    public class DotNetApiService : Construct
    {
        public DotNetApiService(Construct scope, string id) : base(scope, id)
        {
            // use CDK to create an api gateway
            var api = new RestApi(this, "hello-api", new RestApiProps
            {
                RestApiName = "helloservice",
                Description = "This service serves a hello message."

            });

            var lambda = new Function(this, "hello", new FunctionProps
            {
                Runtime = Runtime.DOTNET_6,
                Code = Code.FromAsset("../cdk2/src/AWSLambda1/bin/Release/net6.0/publish"),
                Handler = "APILambda::APILambda.Function::FunctionHandler",
                MemorySize = 512,
                Architecture = Architecture.ARM_64,
            });
            var lambda2 = new Function(this, "goodbye", new FunctionProps
            { 
                Runtime = Runtime.DOTNET_6,
                Code = Code.FromAsset("../cdk2/src/AWSLambda1/bin/Release/net6.0/publish"),
                Handler = "APILambda::APILambda.Function::FunctionHandlerGoodbye",
                MemorySize = 512,
                Architecture = Architecture.ARM_64,
            });
            
            var apiIntegration = new LambdaIntegration(
                lambda, 
                new LambdaIntegrationOptions 
                { 
                    AllowTestInvoke = false
                });
            
            var apiIntegration2 = new LambdaIntegration(
                lambda2,
                new LambdaIntegrationOptions
                {
                    AllowTestInvoke = false 
                });

            api.Root.AddMethod("GET", apiIntegration);
            api.Root.AddResource("goodbye").AddMethod("GET", apiIntegration2);
        }
    }
}
