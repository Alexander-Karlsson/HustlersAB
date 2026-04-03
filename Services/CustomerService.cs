using Services.Interfaces;

namespace Services;

public class CustomerService(ICustomerRepository repo) : ICustomerService
{
    
}