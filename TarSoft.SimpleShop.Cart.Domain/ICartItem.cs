using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarSoft.SimpleShop.Core.Enums;

namespace TarSoft.SimpleShop.Cart.Domain
{
    public interface ICartItem //L in SOLID, can be used in different aspects now, newcart, existingcart
    {
        string CartCookie { get; }
        int CartId { get; set; }
        int CartItemId { get; }
        decimal CurrentPrice { get; }
        int ProductId { get; }
        int Quantity { get; }
        DateTime SelectedDateTime { get; }
        EObjectState State { get; }

        void UpdateQuantity(int newQuantity);
    }
}
