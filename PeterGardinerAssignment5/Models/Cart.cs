using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem (Product prod, int qty)
        {
            CartLine line = Lines.Where(p => p.Product.BookId == prod.BookId).FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = prod,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Product prod) =>
            Lines.RemoveAll(x => x.Product.BookId == prod.BookId);

        public virtual void Clear() => Lines.Clear();

        public decimal ComputeTotalSum()
        {
            //this is hard coded make sre it isn't when it comes time to turn in
            
           return (decimal)Lines.Sum( e => e.Quantity * e.Product.Price);
        }
        

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Product Product { get; set; }

            public int Quantity { get; set; }
        }
    }
}
