using OtavioStore.Domain.StoreContext.CustomerCommands.Inputs;
using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.Handlers;
using OtavioStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OtavioStore.Tests
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Otavio";
            command.LastName = "Araujo";
            command.Document = "467181155";
            command.Email = "tav@dev.io";
            command.Phone = "551999876542";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}