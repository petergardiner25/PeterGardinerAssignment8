﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeterGardinerAssignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (Product prod, int qty)
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

        public void RemoveLine(Product prod) =>
            Lines.RemoveAll(x => x.Product.BookId == prod.BookId);

        public void Clear() => Lines.Clear();

        public decimal ComputeTotalSum()
        {
            //this is hard coded make sre it isn't when it comes time to turn in
            
           return Lines.Sum( e => e.Quantity * 25);
        }
        

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Product Product { get; set; }

            public int Quantity { get; set; }
        }
    }
}