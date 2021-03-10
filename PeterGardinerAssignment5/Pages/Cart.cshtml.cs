using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeterGardinerAssignment5.Infrastructure;
using PeterGardinerAssignment5.Models;


namespace PeterGardinerAssignment5.Pages
{
    public class CartModel : PageModel
    {
        private IProductRepository repository;

        public CartModel (IProductRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long BookId, string returnUrl)
        {
            Product prod = repository.Projects.FirstOrDefault(p => p.BookId == BookId);

            Cart.AddItem(prod, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long BookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.BookId == BookId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
