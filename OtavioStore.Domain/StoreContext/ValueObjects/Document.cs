using System.Text.RegularExpressions;
using FluentValidator;
using FluentValidator.Validation;

namespace OtavioStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(Validate(Number), "Document", "Invalid PPS number")
            );
        }

        public string Number { get; private set; }

        public override string ToString()
        {
            return Number;
        }
        
        public bool Validate(string pps)
        {
            return Regex.IsMatch(pps, @"/^(\d{7})([A-Z]{1,2})$/i");
        }
    }
}