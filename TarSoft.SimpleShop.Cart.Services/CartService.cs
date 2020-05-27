using TarSoft.SimpleShop.Cart.Data;
using TarSoft.SimpleShop.Cart.Domain;

namespace TarSoft.SimpleShop.Cart.Services
{
    public class CartService
    {
        private readonly CartDataAccess _dao;

        public CartService(CartDataAccess dao)
        {
            _dao = dao;
        }

        private RevisitedCart InitializeCart(int productId, int quantity,
                                        decimal displayedPrice, string sourceUrl,
                                        string memberCookie)
        {
            var cart = NewCart.CreateCartWithProduct(sourceUrl, memberCookie, productId, quantity, displayedPrice);

            return _dao.StoreCartWithInitialProduct(cart);
        }
    }
}
