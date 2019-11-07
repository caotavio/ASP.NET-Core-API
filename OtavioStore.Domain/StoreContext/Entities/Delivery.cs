using System;
using OtavioStore.Domain.StoreContext.Enums;
using OtavioStore.Shared.Entities;

namespace OtavioStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Processing;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            //If the estimated date of delivery is in the past, do not deliver
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            //If Status is already "Delivered", you cannot cancel
            Status = EDeliveryStatus.Cancelled;
        }
    }
}