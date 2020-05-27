using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarSoft.SimpleShop.Cart.Domain
{
    public interface INewCart
    {
        string CartCookie { get; }
        int Id { get; }
        ICollection<CartItem> CartItems { get; }
        string CustomerCookie { get; }
        int CustomerId { get; }
        DateTime Expires { get; }
        DateTime Created { get; }
        string SourceUrl { get; }

        void CustomerFound(int customerId);
    }
}
