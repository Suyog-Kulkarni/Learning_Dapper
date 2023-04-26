using Microsoft.Extensions.Configuration;
class Program
{
    private static IConfigurationRoot _config;
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
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