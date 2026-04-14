using Entities;
using HustlersAB.Shared.Menus;
using Services.Interfaces.Customers;

namespace HustlersAB.Admin.Menus.CustomerMenus;

public class CustomerMenu(ICustomerService service) : BaseMenu
{
    protected override string[] Options =>
    [
        "Add Customer",
        "Delete Customer",
        "Search Customer(s)",
        "Update Customer",
        "Go Back" 
    ];
    
    protected override string MenuTitle => "menu -> admin -> MANAGE CUSTOMERS";
    protected override bool ExecuteChoice(int selectedIndex)
    {
        switch (selectedIndex)
        {
            case 0:
                AddNewCustomer();
                break;
            case 1:
                // Delete
            case 2:
                SearchCustomers();
                break;
            case 3:
                // Update
            case 4: return true;
        }

        return false;
    } 
    
    private void AddNewCustomer()
    {
        Header("ADD NEW CUSTOMER");
        var customer = GetCustomer();
        var contactInfo = GetContactInfo(customer);
        service.CreateAsync(customer, contactInfo).GetAwaiter().GetResult();
        PrintCreatedCustomer(customer, contactInfo);
    }

    private Customer GetCustomer()
    {
        var customer = new Customer()
        {
            Id = Guid.NewGuid(),
            Name = ReadString("Name")
        };

        return customer;
    }

    private CustomerContactInfo GetContactInfo(Customer customer)
    {
        var contactInfo = new CustomerContactInfo()
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            Email = ReadString("Email"),
            Phone = ReadString("Phone"),
            Address = ReadString("Address"),
            PostalNumber = ReadString("Zip Code")
        };

        return contactInfo;
    }

    private void PrintCreatedCustomer(Customer customer, CustomerContactInfo contactInfo)
    {
        Console.Clear();
        Header("Customer created successfully!");
        Console.WriteLine($"Name: {customer.Name}");
        Console.WriteLine($"Email: {contactInfo.Email}.");
        Console.WriteLine($"Phone: {contactInfo.Phone}");
        Console.WriteLine($"Address: {contactInfo.Address}");
        Console.WriteLine($"Zip Code: {contactInfo.PostalNumber}");
        Console.WriteLine("-----------------------------");
        Console.ReadKey();
    }

    private void SearchCustomers()
    {
        Console.Clear();
        Header("Search Customers");
        var query = ReadString(">");
        
        var customers = service.GetBySearchAsync(query)
            .GetAwaiter()
            .GetResult();

        PrintSearchResult(customers, query);
    }

    private void PrintSearchResult(IEnumerable<Customer> result, string query)
    {
        Header($"Showing results for: {query}");
        
        if (!result.Any())
        {
            Console.WriteLine("No customers found.");
            Pause();
            return;
        }
        
        var count = 0;
        foreach (var c in result)
        {
            Console.WriteLine($"#{++count} - {c.Name}");
            Console.WriteLine($"\tPhone: {c.CustomerContactInfo?.Phone}");
            Console.WriteLine($"\tEmail: {c.CustomerContactInfo?.Email}");
            Console.WriteLine($"\tAddress: {c.CustomerContactInfo?.Address}");
            Console.WriteLine($"\tZip Code: {c.CustomerContactInfo?.PostalNumber}\n");
        }
        
        Pause();
    }
}

