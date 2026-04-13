using System.Text.Json;
using Services.Interfaces.Quotes;
using Services.Models;

namespace EF_MSSQL.Repositories;

public class QuoteRepository : IQuoteRepository
{
    public async Task<QuoteModel> GetQuoteAsync()
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://zenquotes.io");

        var response = await client.GetAsync("/api/random");

        var json = await response.Content.ReadAsStringAsync();

        var quotes = JsonSerializer.Deserialize<List<QuoteModel>>(json);

        return quotes.FirstOrDefault();
    }
}