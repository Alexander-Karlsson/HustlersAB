using Entities;
using System.Threading.Tasks;

namespace Services.Interfaces.CustomerContactInfos;

public interface ICustomerContactInfoRepository
{
    Task<CustomerContactInfo> CreateAsync(CustomerContactInfo contactInfo);
}
