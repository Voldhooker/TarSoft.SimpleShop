using System;
using TarSoft.SimpleShop.Core.Enums;
using TarSoft.SimpleShop.Core.Interfaces;

namespace TarSoft.SimpleShop.Cart.Domain
{
    public class CartItem : ICartItem, IStateObject
    {
        public string CartCookie { get; private set; }
        public int CartId { get; set; }
        public int CartItemId { get; private set; }
        public decimal CurrentPrice { get; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime SelectedDateTime { get; }
        public EObjectState State { get; private set; }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity < 0)
                throw new ArgumentException("Quantity cannot be less than zero");

            if (Quantity != newQuantity)
            {
                Quantity = newQuantity;
                State = EObjectState.Modified;
            }
        }

        //Factory methods here to control the creation of objects, we want to encapsulate behaviour
        //This method is for new carts, the next one is for existing carts
        public static CartItem Create(int productId, int quantity, decimal displayedPrice, string cartCookie)
        {
            return new CartItem(productId, quantity, displayedPrice, cartCookie);
        }

        public static CartItem Create(int productId, int quantity, decimal displayedPrice, int cartId)
        {
            return new CartItem(productId, quantity, displayedPrice, cartId);
        }

        private CartItem(int productId, int quantity, decimal displayedPrice, string cartCookie)
        {
            CartCookie = cartCookie;
            ProductId = productId;
            CurrentPrice = displayedPrice;
            Quantity = quantity;
            SelectedDateTime = DateTime.UtcNow;
            State = EObjectState.Added;
        }

        private CartItem(int productId, int quantity, decimal displayedPrice, int cartId)
        {
            ProductId = productId;
            Quantity = quantity;
            CurrentPrice = displayedPrice;
            CartId = cartId;
            SelectedDateTime = DateTime.UtcNow;
            State = EObjectState.Added;
        }

        private CartItem()
        {

        }
    }
}
