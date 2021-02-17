using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment5.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ProductDbContext _context;

        //constructor

        public EFProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Projects => _context.Projects;
    }
}
