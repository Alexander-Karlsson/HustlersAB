using Entities;
using System.Threading.Tasks;

namespace EF_MSSQL.Repositories;

using Services.Interfaces.CustomerContactInfos;

public class CustomerContactInfoRepository(StoreDbContext db) : ICustomerContactInfoRepository
{
    public async Task<CustomerContactInfo> CreateAsync(CustomerContactInfo contactInfo)
    {
        await db.CustomerContactInfo.AddAsync(contactInfo);
        await db.SaveChangesAsync();

        return contactInfo;
    }
}
