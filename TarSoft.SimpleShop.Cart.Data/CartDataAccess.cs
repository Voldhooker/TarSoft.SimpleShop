using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarSoft.SimpleShop.Cart.Domain;

namespace TarSoft.SimpleShop.Cart.Data
{
    public class CartDataAccess
    {
        private readonly ShoppingCartContext _context;
        //private readonly ReferenceContext _refContext;

        public CartDataAccess(ShoppingCartContext context)
        {
            _context = context;
            //_refContext = refContext;
        }
        public RevisitedCart StoreCartWithInitialProduct(NewCart cart)
        {

            throw new NotImplementedException();
        }
    }
}
