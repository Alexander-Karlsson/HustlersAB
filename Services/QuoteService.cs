using Services.Interfaces.Quotes;
using Services.Models;

namespace Services;

public class QuoteService(IQuoteRepository repo) : IQuoteService
{
    public async Task<QuoteModel> GetQuoteAsync()
    {
        return await repo.GetQuoteAsync();
    }
}