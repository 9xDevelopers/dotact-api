using System.Net.Http;
using System.Reflection;
using app.api;
using app.core.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace app.integrationtest
{
    public class TestClientProvider
    {
        public TestClientProvider()
        {
            var projectDir = AppHelper.GetProjectPath("", typeof(Startup).GetTypeInfo().Assembly);
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseContentRoot(projectDir)
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(projectDir)
                    .AddJsonFile("appsettings.json")
                    .Build()
                ).UseStartup<Startup>());
            Client = server.CreateClient();
        }

        public HttpClient Client { get; }


        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .Build();
            return config;
        }
    }
}