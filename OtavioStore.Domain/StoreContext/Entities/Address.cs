using FluentValidator;
using OtavioStore.Domain.StoreContext.Enums;
using OtavioStore.Shared.Entities;

namespace OtavioStore.Domain.StoreContext.Entities
{
    public class Address : Entity
    {
        public Address(
            string street,
            string number,
            string complement,
            string city,
            string county,
            string country,
            string postCode,
            EAddressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            City = city;
            County = county;
            Country = country;
            PostCode = postCode;
            Type = type;
        }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }
        public string PostCode { get; private set; }
        public EAddressType Type { get; private set; }

        public override string ToString()
        {
            return $"{Number}, {Street} - {City}/{County}";
        }
    }
}