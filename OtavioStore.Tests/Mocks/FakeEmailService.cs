using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.Services;

namespace OtavioStore.Tests
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}