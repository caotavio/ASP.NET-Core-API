using System;
using System.Collections.Generic;
using FluentValidator;
using FluentValidator.Validation;
using OtavioStore.Shared.Commands;

namespace OtavioStore.Domain.StoreContext.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {   
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(Customer.ToString(), 36, "Customer", "Invalid client identifier")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "No order items were found")
            );
            return Valid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; } 
        public decimal Quantity { get; set; }
    }
}