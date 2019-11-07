using FluentValidator;
using FluentValidator.Validation;

namespace OtavioStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "The name should have at least 3 characters")
                .HasMaxLen(FirstName, 40, "FirstName", "The name should have 40 characters maximum")
                .HasMinLen(LastName, 3, "LastName", "The last name should have at least 3 characters")
                .HasMaxLen(LastName, 40, "LastName", "The last name should have 40 characters maximum")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}