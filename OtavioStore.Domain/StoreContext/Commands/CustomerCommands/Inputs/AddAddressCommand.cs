using System;
using FluentValidator;
using OtavioStore.Domain.StoreContext.Enums;
using OtavioStore.Shared.Commands;

namespace OtavioStore.Domain.StoreContext.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public EAddressType Type { get; set; }

        bool ICommand.IsValid()
        {
            return Valid;
        }
    }
}