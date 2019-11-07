using FluentValidator;
using FluentValidator.Validation;
using OtavioStore.Shared.Commands;

namespace OtavioStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "The name should have at least 3 characters")
                .HasMaxLen(FirstName, 40, "FirstName", "The name should have 40 characters maximum")
                .HasMinLen(LastName, 3, "LastName", "The last name should have at least 3 characters")
                .HasMaxLen(LastName, 40, "LastName", "The last name should have 40 characters maximum")
                .IsEmail(Email, "Email", "The email is invalid")
                .HasLen(Document, 9, "Document", "Invalid PPS nember")
            );
            return Valid;
        }
    }
}
        