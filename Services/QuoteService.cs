using Services.Interfaces.Quotes;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services;

public class QuoteService(IQuoteRepository repo) : IQuoteService
{
    public async Task<QuoteModel> GetQuoteAsync()
    {
        return await repo.GetQuoteAsync();
    }
}
