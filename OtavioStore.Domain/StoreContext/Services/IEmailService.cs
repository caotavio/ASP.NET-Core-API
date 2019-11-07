using OtavioStore.Domain.StoreContext.Entities;

namespace OtavioStore.Domain.StoreContext.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}