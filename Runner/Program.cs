using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;

class Program
{
    private static IConfigurationRoot _config;
    static void Main(string[] args)
    {
        Initialize();
       GetAll();
        var id = Add();
        find(id);
    }
    static void GetAll()
    {

        var repository = CreateRepository();

        var contacts =  repository.GetAll();
        Console.WriteLine($"Total Count is {contacts.Count}");
        Debug.Assert(contacts.Count == 6);
        contacts.Output();
    }
    static int Add()
    {
        var repository = CreateRepository();

        var contacts = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "abc@gmail.com",
            Company = "HCL",
            Title = "Developer"
        };

        repository.Add(contacts);
        Debug.Assert(contacts.Id != 0);
        Console.WriteLine("Added Contact");
        Console.WriteLine($"New ID{contacts.Id}");

        return contacts.Id;

        
    }
    static void find(int id)
    {
        var repository = CreateRepository();

        var contacts = repository.Find(id);

        Console.WriteLine();
        contacts.Output();
        Debug.Assert(contacts.FirstName == "John");
        Debug.Assert(contacts.LastName == "Doe");


    }
    private static void Initialize()
    {
        var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        _config = builder.Build();
    }

    private static IContactRepository CreateRepository()
    {
        return new ContactRepository(_config.GetConnectionString("DefaultConnection"));
        //return new ContactRepositoryContrib(config.GetConnectionString("DefaultConnection"));
    }
}