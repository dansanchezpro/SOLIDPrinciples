using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OCP;

Console.WriteLine("SOLID Principles: OCP");
ServiceContainer.ConfigureServices(services =>
{
    services.AddTransient<IFactoryDb>(s => new SqlServerFactoryDb(ServiceContainer.Configuration.GetConnectionString("SQLServerConnection")));
    services.AddTransient<IFactoryDb>(s => new MySQLFactoryDb(ServiceContainer.Configuration.GetConnectionString("MySQLConnection")));
    services.AddTransient<FactoryService>();
});

var factoryService = ServiceContainer.GetService<FactoryService>();
var instanceSQLServer = factoryService.Crear("SQLServer");
var instanceMySQL = factoryService.Crear("MySQL");
Console.WriteLine(instanceSQLServer.TellTye());
Console.WriteLine(instanceMySQL.TellTye());

Console.ReadKey();