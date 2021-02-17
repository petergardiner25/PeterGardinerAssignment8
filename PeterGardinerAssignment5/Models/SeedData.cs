using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            ProductDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ProductDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Projects.Any())
            {
                context.Projects.AddRange(
                    
                    new Product
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Fiction, Classic",
                        Price = "$9.95"
                    },

                    new Product
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris Kearns",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction, Biography",
                        Price = "$14.58"
                    },

                    new Product
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Category = "Non-Fiction, Biography",
                        Price = "$21.54"

                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
