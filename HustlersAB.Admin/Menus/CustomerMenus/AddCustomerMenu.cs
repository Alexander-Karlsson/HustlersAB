using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Customers;

namespace HustlersAB.Admin.Menus.CustomerMenus;

public class AddCustomerMenu(ICustomerService service) : BaseMenu
{
    protected override string[] Options =>
    [
        "Add New Customer",
        "Go Back" 
    ];
    
    protected override string MenuTitle => "menu -> admin -> ADD CUSTOMER";
    
     protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                AddNewCustomer();
                break;
            case 1:
                return true;
        }
        return false;
    } 

    private void AddNewCustomer()
    {
        Header("ADD NEW CUSTOMER");
        
        var customer = new Customer()
        {
            Id = Guid.NewGuid(),
            Name = ReadString("Name: ")
        };

        var contactInfo = new CustomerContactInfo()
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            Email = ReadString("Email: "),
            Phone = ReadString("Phone: "),
            Address = ReadString("Address: "),
            PostalNumber = ReadString("Zip Code: ")
        };
        
        service.CreateAsync(customer, contactInfo).GetAwaiter().GetResult();

        Console.Clear();
        
        Console.WriteLine("Product created successfully!");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Name: {customer.Name}");
       
        Console.WriteLine($"Email {contactInfo.Email}.");
        Console.WriteLine($"Phone: {contactInfo.Phone}");
        Console.WriteLine($"Address: {contactInfo.Address}");
        Console.WriteLine($"Zip Code: {contactInfo.PostalNumber}");
        Console.WriteLine("-----------------------------");
        Console.ReadKey();
    }
}