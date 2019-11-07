using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.Enums;
using OtavioStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OtavioStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            // Recover the products from the database
            var name = new Name("Otavio", "Araujo");
            var document = new Document("467181155");
            var email = new Email("tav@dev.io");
            _customer = new Customer(name, document, email, "551999876542");
            _order = new Order(_customer);

            _mouse = new Product("Gamer Mouse", "Gamer Mouse", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Gamer Keyboard", "Gamer Keyboard", "Keyboard.jpg", 100M, 10);
            _chair = new Product("Gamer Chair", "Gamer Chair", "Chair.jpg", 100M, 10);
            _monitor = new Product("Gamer Monitor", "Gamer Monitor", "Monitor.jpg", 100M, 10);
        }

        // Able to create an order
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        // When the order is created, status should be CREATED
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // When adding a new item, the item quantity should increase
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // When adding a new item, the item quantity in stock should decrease
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityInStock, 5);
        }

        // When confirming an order, a number should be generated
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.PlaceOrder();
            Assert.AreNotEqual("", _order.Number);
        }

        // When paying an order, status should be PAID
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Given 10 more products, there should be 2 more deliveries
        [TestMethod]
        public void ShouldTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // When the order is cancelled, the status should be CANCELLED
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Cancelled, _order.Status);
        }

        // When the order is cancelled, the deliveires should be CANCELLED
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Cancelled, x.Status);
            }
        }
    }
}