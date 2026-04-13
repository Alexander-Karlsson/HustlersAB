using Services.Models;

namespace Services.Interfaces.Quotes;

public interface IQuoteRepository
{
    Task<QuoteModel> GetQuoteAsync();
}