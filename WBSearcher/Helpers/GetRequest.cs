namespace WBSearcher.Helpers
{
    public class GetRequest
    {
        private readonly string _address;

        public GetRequest(string address)
        {
            _address = address;
        }

        public async Task<string> GetAsync()
        {
            using var client = new HttpClient();
            var repsonse = await client.GetAsync(_address);
            return await repsonse.Content.ReadAsStringAsync();
        }
    }
}
