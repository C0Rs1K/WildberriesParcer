using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WBSearcher.Models;

namespace WBSearcher.Helpers
{
    public class WildBerriesSearcher
    {
        private const string search = "https://search.wb.ru/exactmatch/ru/male/v4/search?appType=1&couponsGeo=12,3,18,15,21&curr=rub&dest=-1029256,-102269,-1278703,-1255563&emp=0&lang=ru&locale=ru&pricemarginCoeff=1.0&reg=1&regions=68,64,83,4,38,80,33,70,82,86,75,30,69,22,66,31,40,1,48,71&resultset=catalog&sort=popular&spp=20&suppressSpellcheck=false"; 

        public async Task<List<Card>?> GetCollectionAsync(string searchLine)
        {
            var getRequest = new GetRequest(search + $"&query={searchLine}");

            var request = await getRequest.GetAsync();

            var root = JsonSerializer.Deserialize<Root>(request);

            FixPrices(root?.Data.Products);

            return root?.Data.Products;
        }
        
        private void FixPrices(List<Card>? cards)
        {
            if (cards is null)
            {
                return;
            }

            foreach (var card in cards)
            {
                card.Price /= 100;
            }
        }

        private class Data
        {
            [JsonPropertyName("products")]
            public List<Card> Products { get; set; }
        }
        private class Root
        {
            [JsonPropertyName("data")]
            public Data Data { get; set; }
        }
    }
}
