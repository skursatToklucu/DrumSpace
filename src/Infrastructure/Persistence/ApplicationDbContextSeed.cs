using System;
using System.Collections.Generic;
using System.Globalization;
using DrumSpace.Domain.Entities;
using DrumSpace.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using DrumSpace.Domain.Enums;
using static System.Linq.Enumerable;



namespace DrumSpace.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            IdentityRole administratorRole = new("Administrator");
            IdentityRole standartRole = new("Standard");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
                await roleManager.CreateAsync(standartRole);
            }

            ApplicationUser administrator = new()
                { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (context.Rudiments.Any() == false)
            {
                var list = new[] { "R", "L", "r", "l" };
                for (var i = 3; i <= 7; i++)
                {
                    foreach (var combination in Repeat(list, i).CartesianProduct())
                    {
                        context.Rudiments.Add(new Rudiment
                        {
                            Pattern = string.Join("", combination.ToArray()),
                            Type = i
                        });
                    }
                }

                await context.SaveChangesAsync();
            }
        }

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item }));
        }
    }
}