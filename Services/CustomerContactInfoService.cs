using Entities;
using Services.Interfaces.CustomerContactInfos;
using System.Threading.Tasks;

namespace Services;

public class CustomerContactInfoService(ICustomerContactInfoRepository repo) : ICustomerContactInfoService
{
    public Task<CustomerContactInfo> CreateAsync(CustomerContactInfo contactInfo)
        => repo.CreateAsync(contactInfo);
}
