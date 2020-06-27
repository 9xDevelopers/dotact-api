using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace app.integrationtest
{
    public class AuthorApiIntegrationTest
    {
        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/authors");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}