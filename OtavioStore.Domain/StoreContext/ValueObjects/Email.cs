using FluentValidator;
using FluentValidator.Validation;

namespace OtavioStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "The email is invalid")
            );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}