using Commander.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Commander.Data
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<CommanderContext>());
            }
        }

        public static void SeedData(CommanderContext context)
        {
            if (!context.Commands.Any())
            {
                System.Console.WriteLine("Adding data - seeding...");

                context.Commands.AddRange(
                    new Command { HowTo = "How to create a migration", Line = "dotnet ef migrations add <Name of migration>", Platform = "EF Core" },
                    new Command { HowTo = "How to apply migrations", Line = "dotnet ef database update", Platform = "EF Core" },
                    new Command { HowTo = "Run a .NET Core app", Line = "dotnet run", Platform = ".NET Core CLI" },
                    new Command { HowTo = "Rollback a migration", Line = "dotnet ef migration remove", Platform = "EF Core" },
                    new Command { HowTo = "Install a new package", Line = "dotnet add package <Name of the package>", Platform = ".NET Core CLI" },
                    new Command { HowTo = "Run a .NET Core app", Line = "dotnet run", Platform = ".NET Core CLI" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}