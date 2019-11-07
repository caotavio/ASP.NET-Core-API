using System;
using FluentValidator;
using OtavioStore.Shared.Entities;

namespace OtavioStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityInStock < Quantity)
                AddNotification("Quantity", "Unfortunately there are not enough produts in stock to process your order");
            
            product.DecreaseQuantity(quantity);
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        
    }
}