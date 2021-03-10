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

        public CartModel (IProductRepository repo)
        {
            repository = repo;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
            ReturnUrl = ReturnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long BookId, string returnUrl)
        {
            Product prod = repository.Projects.FirstOrDefault(p => p.BookId == BookId);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddItem(prod, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
