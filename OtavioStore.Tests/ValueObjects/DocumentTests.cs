using Microsoft.VisualStudio.TestTools.UnitTesting;
using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.ValueObjects;

namespace OtavioStore.Tests
{
[TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("286591703");
            invalidDocument = new Document("123456789");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.Valid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
