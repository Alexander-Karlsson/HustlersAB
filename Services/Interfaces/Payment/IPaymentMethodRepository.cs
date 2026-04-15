using System;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces.Payment;

public interface IPaymentMethodRepository
{
    Task<IEnumerable<PaymentMethod>> GetPaymentMethodAsync();
}