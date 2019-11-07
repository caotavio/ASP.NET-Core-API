using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using OtavioStore.Domain.StoreContext.Enums;
using OtavioStore.Shared.Entities;

namespace OtavioStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly List<OrderItem> _items;
        private readonly List<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if(quantity < product.QuantityInStock)
                AddNotification("OrderItem", $"Unfortunately we do not have {quantity} of units of the product {product.Title} in stock.");
                
            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        //Place an order
        public void PlaceOrder()
        {
            //Generates order number
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_items.Count == 0)
                AddNotification("Order", "This order has no items");
            //generate invoice
            //separate order for delivery
        }

        //Pay and order
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        //Send an order AFTER ITS PAID
        public void Ship()
        {
            //When you have 5 products you generate one delivery
            var deliveries = new List<Delivery>();
            var count = 1;

            //Separate the deliveries in packs of 5 orders
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Ships all deliveries
            deliveries.ForEach(x => x.Ship());

            //Adds all deliveries to the order
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        //Cancel an order
        public void Cancel()
        {
            Status = EOrderStatus.Cancelled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}