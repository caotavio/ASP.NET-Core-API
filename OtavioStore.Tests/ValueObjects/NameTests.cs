using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Araujo");
            Assert.AreEqual(false, name.Valid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}

//This is just an example... FluentValidator already has the tests for Name.