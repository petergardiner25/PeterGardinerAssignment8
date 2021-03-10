using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeterGardinerAssignment5.Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace PeterGardinerAssignment5.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart")
                ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product prod, int qty)
        {
            base.AddItem(prod, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveLine(Product prod)
        {
            base.RemoveLine(prod);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }

}
