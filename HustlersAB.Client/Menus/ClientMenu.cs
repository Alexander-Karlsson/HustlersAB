using Entities;
using HustlersAB.Admin.Menus;
using HustlersAB.Shared;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Payment;
using Services.Interfaces.Products;
using Services.Interfaces.Shipping;
using System;
using System.Collections.Generic;
using System.Text;

namespace HustlersAB.Client.Menus;

public class ClientMenu(IProductService service, Cart cart, IShippingService shippingService, IPaymentMethodService PaymentService) : BaseMenu
{
    protected override string[] Options =>
        [
        "Browse Products",
        "View Cart",
        "Exit"
        ];

    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                new ProductsMenu(service, cart).Start();
                return false;
            case 1:
                new ShopingCartMenu(cart, shippingService, PaymentService).Start();
                return false;
            default:
                break;
        }
        return true;
    }
}
