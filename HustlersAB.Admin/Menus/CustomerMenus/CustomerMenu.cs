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
            case 0: AddCustomer(); break;
            case 1: DeleteCustomer(); break;
            case 2: SearchCustomers(); break;
            case 3: UpdateCustomer(); break;
            case 4: return true;
        }
        return false;
    }

    // Crud metoder

    private void AddCustomer()
    {
        Header("ADD NEW CUSTOMER");

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = ReadRequiredString("Name")
        };

        var contactInfo = BuildContactInfo(customer);
        service.CreateAsync(customer, contactInfo).GetAwaiter().GetResult();

        Console.Clear();
        Header("Customer created successfully!");
        PrintCustomerDetails(customer, contactInfo);
        Console.ReadKey();
    }

    private void SearchCustomers()
    {
        Header("SEARCH CUSTOMERS");
        var query = ReadString(">");
        if (query is null) { Pause(); return; }

        var customers = service.GetBySearchAsync(query).GetAwaiter().GetResult().ToList();

        if (!customers.Any())
        {
            Console.WriteLine("No customers found.");
            Pause();
            return;
        }

        Header($"Showing results for: {query}");
        PrintCustomerList(customers);
        Pause();
    }

    private void DeleteCustomer()
    {
        Header("DELETE CUSTOMER");
        var selected = PromptSelectCustomer();
        if (selected is null) return;

        if (!ConfirmDelete(selected.Name))
        {
            Pause("Deletion cancelled.");
            return;
        }

        service.DeleteAsync(selected.Id).GetAwaiter().GetResult();
        Pause($"Customer \"{selected.Name}\" deleted successfully.");
    }

    private void UpdateCustomer()
    {
        Header("UPDATE CUSTOMER");
        var selected = PromptSelectCustomer();
        if (selected is null) return;

        selected.Name = ReadUpdatedString("Name", selected.Name);
        selected.CustomerContactInfo = BuildContactInfo(selected, isUpdate: true);

        service.UpdateAsync(selected).GetAwaiter().GetResult();
        Pause($"Customer \"{selected.Name}\" updated successfully.");
    }

    // Goa helpers

    private Customer? PromptSelectCustomer()
    {
        var customers = service.GetAllAsync().GetAwaiter().GetResult().ToList();

        if (!customers.Any())
        {
            Pause("No customers found.");
            return null;
        }

        PrintCustomerList(customers);

        var choice = ReadInt("Choose customer number");
        if (choice is null || choice < 1 || choice > customers.Count)
        {
            Invalid();
            return null;
        }

        return customers[(int)choice - 1];
    }

    private CustomerContactInfo BuildContactInfo(Customer customer, bool isUpdate = false)
    {
        string Read(string label, string current) =>
            isUpdate ? ReadUpdatedString(label, current) : ReadRequiredString(label);

        var existing = customer.CustomerContactInfo;

        return new CustomerContactInfo
        {
            Id = existing?.Id ?? Guid.NewGuid(),
            CustomerId = customer.Id,
            Email = Read("Email", existing?.Email ?? ""),
            Phone = Read("Phone", existing?.Phone ?? ""),
            Address = Read("Address", existing?.Address ?? ""),
            PostalNumber = Read("Zip Code", existing?.PostalNumber ?? "")
        };
    }

    private void PrintCustomerList(List<Customer> customers)
    {
        var count = 0;
        foreach (var c in customers)
            Console.WriteLine($"{++count}. {c.Name} - {c.CustomerContactInfo?.Phone} - {c.CustomerContactInfo?.Email}");
    }

    private void PrintCustomerDetails(Customer customer, CustomerContactInfo contactInfo)
    {
        Console.WriteLine($"Name:     {customer.Name}");
        Console.WriteLine($"Email:    {contactInfo.Email}");
        Console.WriteLine($"Phone:    {contactInfo.Phone}");
        Console.WriteLine($"Address:  {contactInfo.Address}");
        Console.WriteLine($"Zip Code: {contactInfo.PostalNumber}");
        Console.WriteLine("-----------------------------");
    }

    private string ReadRequiredString(string label)
    {
        string? input;
        do
        {
            Console.Write($"{label}: ");
            input = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(input))
                Console.WriteLine("This field is required.");
        } while (string.IsNullOrEmpty(input));
        return input;
    }
}