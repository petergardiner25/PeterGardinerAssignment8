using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment5.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext (DbContextOptions<ProductDbContext> options) : base (options)
        {

        }

        public DbSet<Product> Projects { get; set; }
    }
}
