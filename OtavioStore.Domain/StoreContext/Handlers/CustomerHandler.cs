using System;
using FluentValidator;
using OtavioStore.Domain.StoreContext.CustomerCommands.Inputs;
using OtavioStore.Domain.StoreContext.Entities;
using OtavioStore.Domain.StoreContext.Repositories;
using OtavioStore.Domain.StoreContext.Services;
using OtavioStore.Domain.StoreContext.ValueObjects;
using OtavioStore.Shared.Commands;

namespace OtavioStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
            
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Check if PPS already exists on db
            if(_repository.CheckDocument(command.Document))
                AddNotification("Document", "This PPS number is already in use");

            //check if email already exists
            if(_repository.CheckEmail(command.Email))
                AddNotification("Email", "This E-mail is already in use");
            
            //Create VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Create entity
            var customer = new Customer(name, document, email, command.Phone);

            //Validate entities and VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid)
                return new CommandResult(
                    false,
                    "Please, provide the correct information",
                    Notifications);
            
            //Persist client
            _repository.Save(customer);

            //Send a welcome email
            _emailService.Send(email.Address, "tav@dev.io", "Welcome", "Welcome to Otavio Store!");
            
            //Return resul to the screen
            return new CommandResult(true, "Welcome to Otavio Store", new {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address
            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}