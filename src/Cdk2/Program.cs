using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdk2
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new Cdk2Stack(app, "Cdk2Stack", new StackProps
            {
                Description = "Our first CDK stack",
                Env = new Amazon.CDK.Environment
                {
                    Region = "ap-southeast-2",
                }
            });
            app.Synth();
        }
    }
}
