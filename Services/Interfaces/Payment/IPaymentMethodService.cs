using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Payment;

public interface IPaymentMethodService
{
    Task<IEnumerable<PaymentMethod>> GetPaymentMethodAsync();
}