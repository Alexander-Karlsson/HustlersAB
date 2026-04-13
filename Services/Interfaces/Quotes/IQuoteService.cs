using Services.Models;

namespace Services.Interfaces.Quotes;

public interface IQuoteService
{
    Task<QuoteModel> GetQuoteAsync();
}