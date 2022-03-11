// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Runtime;
using System.Xml;
using DbUp;
using DbUp.Engine.Filters;
using DbUp.Helpers;

Console.WriteLine("DB UP!");


var connectionString = args.Length > 0 ? args[0] : "";

var migrator = DeployChanges
    .To
    .SqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(),name => name.StartsWith("Oponeo.DbUp.Release"))
    .LogToConsole()
    .Build();

var views = DeployChanges
    .To
    .SqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), name => name.StartsWith("Oponeo.DbUp.View"))
    .LogToConsole()
    .JournalTo(new NullJournal())
    .Build();

var migrationResult = migrator.PerformUpgrade();

if (migrationResult.Successful)
{
    Console.WriteLine("Success");
}
else
{
#if DEBUG
    Console.ReadLine();
#endif
    Console.WriteLine(migrationResult.Error);
}