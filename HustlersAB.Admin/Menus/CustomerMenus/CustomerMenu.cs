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
                DeleteCustomer();
                break;
            case 2:
                SearchCustomers();
                break;
            case 3:
                UpdateCustomer();
                break;
            case 4: return true;
        }

        return false;
    } 
    
    private void AddNewCustomer()
    {
        Header("ADD NEW CUSTOMER");
        var customer = CreateCustomer();
        var contactInfo = GetContactInfo(customer);
        service.CreateAsync(customer, contactInfo).GetAwaiter().GetResult();
        PrintCreatedCustomer(customer, contactInfo);
    }

    private Customer CreateCustomer()
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
            Id = customer.CustomerContactInfo?.Id ?? Guid.NewGuid(),
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
        Header("Search Customers");
        var query = ReadString(">");
        
        var customers = service.GetBySearchAsync(query)
            .GetAwaiter()
            .GetResult();

        PrintSearchResult(customers, query);
    }

    private void PrintSearchResult(IEnumerable<Customer> result, string query)
    {
        if (!result.Any())
        {
            Console.WriteLine("No customers found.");
            Pause();
            return;
        }
        
        Header($"Showing results for: {query}");
        
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
    
    private void DeleteCustomer()
    {
        Header("DELETE CUSTOMER");

        var customers = service.GetAllAsync().GetAwaiter().GetResult().ToList();
        if (!customers.Any())
        {
            Pause("No customers found.");
            return;
        }

        PrintCustomerList(customers);

        var choice = ReadInt("Choose customer number to delete: ");
        if (choice is null || choice < 1 || choice > customers.Count)
        {
            Invalid();
            return;
        }

        var selected = customers[(int)choice - 1];

        if(!ConfirmDelete(selected.Name))
        {
            Pause("Deletion cancelled.");
            return;
        }
        
        service.DeleteAsync(selected.Id).GetAwaiter().GetResult();

        Console.Clear();
        Pause($"Customer \"{selected.Name}\" deleted successfully.");
    }

    private void PrintCustomerList(List<Customer> customers)
    {
        var count = 0;
        foreach (var c in customers)
        {
            Console.WriteLine($"{++count}. {c.Name} - {c.CustomerContactInfo?.Phone} -  {c.CustomerContactInfo?.Email}");
        }
    }

    private void UpdateCustomer()
    {
        Header("UPDATE CUSTOMER");
        var customers = service.GetAllAsync().GetAwaiter().GetResult().ToList();
        if (!customers.Any())
        {
            Pause("No customers found.");
            return;
        }

        PrintCustomerList(customers);
        
        var choice = ReadInt("Choose customer number to update: ");
        if (choice is null || choice < 1 || choice > customers.Count)
        {
            Invalid();
            return;
        }

        var selected = customers[(int)choice - 1];
        
        selected.Name = ReadString("Name") ?? selected.Name;
        selected.CustomerContactInfo = GetUpdatedContactInfo(selected);
        
        service.UpdateAsync(selected).GetAwaiter().GetResult();

        Console.Clear();
        Pause($"Customer {selected.Name} successfully updated.");
    }
    
    private CustomerContactInfo GetUpdatedContactInfo(Customer customer)
    {
        var e = customer.CustomerContactInfo!;
        return new()
        {
            Id = e.Id,
            CustomerId = customer.Id,
            Email = ReadUpdatedString("Email", e.Email),
            Phone = ReadUpdatedString("Phone", e.Phone),
            Address = ReadUpdatedString("Address", e.Address),
            PostalNumber = ReadUpdatedString("Zip Code", e.PostalNumber)
        };
    }


}

