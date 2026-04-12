using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Quotes;

public interface IQuoteService
{
    Task<QuoteModel> GetQuoteAsync();
}
