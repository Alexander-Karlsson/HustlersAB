using Entities;
using System.Threading.Tasks;

namespace Services.Interfaces.CustomerContactInfos;

public interface ICustomerContactInfoService
{
    Task<CustomerContactInfo> CreateAsync(CustomerContactInfo contactInfo);
}
