using System;
using System.Linq;
using System.Reflection;
using DbUp;
namespace IssueManager.Database.Migration
{
    class Program
    {
        static int Main(string[] args)
        {
            var connectionString =
    args.FirstOrDefault()
    ?? "Server=localhost,8888;Database=IssueManager;User Id=sa;Password=Password@977;";
EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
        Console.ReadLine();
#endif
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
