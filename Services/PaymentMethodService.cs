using Entities;
using Services.Interfaces.Payment;

namespace Services;

public class PaymentMethodService(IPaymentMethodRepository repo) : IPaymentMethodService
{
    public async Task<IEnumerable<PaymentMethod>> GetPaymentMethodAsync()
        => await repo.GetPaymentMethodAsync();
}

