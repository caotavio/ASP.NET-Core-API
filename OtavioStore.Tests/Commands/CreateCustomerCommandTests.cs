using OtavioStore.Domain.StoreContext.CustomerCommands.Inputs;
using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OtavioStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Otavio";
            command.LastName = "Araujo";
            command.Document = "467181155";
            command.Email = "tav@dev.io";
            command.Phone = "551999876542";

            Assert.AreEqual(true, command.IsValid());
        }
    }
}