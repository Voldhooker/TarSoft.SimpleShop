using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarSoft.SimpleShop.Core;

namespace TarSoft.SimpleShop.Cart.Domain
{
    public class NewCart : INewCart
    {
        private NewCart(string sourceUrl, string customerCookie)
        {
            if (Uri.IsWellFormedUriString(sourceUrl, UriKind.Absolute))
                SourceUrl = sourceUrl;
            else
                SourceUrl = "";

            CustomerCookie = customerCookie;
            CartItems = new List<CartItem>();

        }

        public string CartCookie { get; private set; }
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public DateTime Expires { get; private set; }
        public DateTime Created { get; private set; }

        public string SourceUrl { get; private set; }

        public ICollection<CartItem> CartItems { get; }

        public string CustomerCookie { get; private set; }

        //Factory method, control and encapsulate
        public static NewCart CreateCartWithProduct(string sourceUrl, string customerCookie, int productId, int quantity, decimal displayedPrice)
        {
            var cart = new NewCart(sourceUrl, customerCookie);
            cart.InitCart();
            cart.InsertNewCartItem(productId, quantity, displayedPrice);
            return cart;
        }

        private void InsertNewCartItem(int productId, int quantity, decimal displayedPrice)
        {
            CartItems.Add(CartItem.Create(productId, quantity, displayedPrice, CartCookie));
        }

        private void InitCart()
        {
            Created = DateTime.Now;
            Expires = Created.Add(ShopSettings.CookieExpiration);
            CartCookie = Guid.NewGuid().ToString();
        }

        public void CustomerFound(int customerId)
        {
            CustomerId = customerId;
        }

    }
}
