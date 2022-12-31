using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;
using Constructs;

namespace Cdk2
{
    public class Cdk2Stack : Stack
    {
        internal Cdk2Stack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            new DotNetApiService(this, "DotNetApiService");
        }
    }
}
