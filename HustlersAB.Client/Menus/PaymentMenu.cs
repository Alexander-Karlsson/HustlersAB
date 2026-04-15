using Entities;
using HustlersAB.Shared.Menus;
using Services;
using Services.Interfaces.Payment;
using Services.Interfaces.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Client.Menus
{
    public class PaymentMenu(IPaymentMethodService paymentMethodService, Cart cart) : BaseMenu
    {
        private readonly PaymentMethod _selectedPayment;
        private readonly List<PaymentMethod> _paymentMethodService = paymentMethodService
        .GetPaymentMethodAsync()
        .GetAwaiter()
        .GetResult()
        .ToList();
        protected override string[] Options
        {
            get
            {
                var options = new List<string>();

                if (_paymentMethodService.Count == 0)
                {
                    options.Add("No Payment options available");
                }
                else
                {
                    for (int i = 0; i < _paymentMethodService.Count; i++)
                    {
                        var s = _paymentMethodService[i];
                        var sel = _selectedPayment != null && _selectedPayment.Id == s.Id ? " (selected)" : string.Empty;
                        options.Add($"{s.PaymentName}");
                    }
                }
                options.Add($"Back");
                return options.ToArray();
            }
        }

        protected override bool ExecuteChoice(int selectedIndex)
        {
            if (Math.Max(_paymentMethodService.Count, 0))
        }
    }
}
