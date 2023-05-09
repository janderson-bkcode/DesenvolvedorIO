using System;

namespace DevStore.Bff.Checkout.Models
{
    public class ShoppingCartItemDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}