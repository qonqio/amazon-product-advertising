namespace Qonq.Amazon.Tests
{
    public class UnitTest1
    {
        AmazonClient _client;

        public UnitTest1()
        {
            var accessKey = "";
            var secretKey = "";
            var parnterTag = "";
            var endpoint = AmazonEndpoint.US;
            var signer = new AwsSigner();
            _client = new AmazonClient(signer, accessKey, secretKey, endpoint, parnterTag);
        }


        [Fact]
        public async Task Test1()
        {

            try
            {

                var result = await _client.SearchItemsAsync("Mastering Terraform");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}