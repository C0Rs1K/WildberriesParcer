using WBSearcher.DataWriter;
using WBSearcher.Helpers;
using WBSearcher.Models;

class WBParcer
{
    private readonly IDataWriter<Card> _writer;
    private readonly string _request;
    public WBParcer(IDataWriter<Card> writer, string request)
    {
        _writer = writer;
        _request = request;
    }

    public async Task SaveCardsAsync()
    {
        var searcher = new WildBerriesSearcher();
        var collection = await searcher.GetCollectionAsync(_request);
        if (collection is null)
        {
            return;
        }

        await _writer.WriteAsync(collection);
    }
}