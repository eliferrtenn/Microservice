using Microservice.Order.Application.Features.CQRS.Commands.AddressCommands;
using Microservice.Order.Application.Interfaces;
using Microservice.Order.Domain.Entities;

namespace Microservice.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand command)
        {
            await _repository.CreateAsync(new Address
            {
                City = command.City,
                Detail = command.Detail,
                District = command.District,
                UserId = command.UserId,
            });
        }

    }
}