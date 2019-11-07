using System;
using FluentValidator;
using OtavioStore.Shared.Entities;

namespace OtavioStore.Domain.StoreContext.Entities
{
    public class Product : Entity
    {
        
        public Product(
            string title,
            string description, 
            string image,
            decimal price,
            decimal quantity)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityInStock = quantity;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityInStock { get; private set; }

        public override string ToString()
        {
            return Title;
        }

        public void DecreaseQuantity(decimal quantity)
        {
            QuantityInStock -= quantity;
        }
    }
}