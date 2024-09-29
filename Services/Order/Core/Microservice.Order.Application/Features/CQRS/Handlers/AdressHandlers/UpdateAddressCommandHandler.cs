using Microservice.Order.Application.Features.CQRS.Commands.AddressCommands;
using Microservice.Order.Application.Interfaces;
using Microservice.Order.Domain.Entities;

namespace Microservice.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var data = await _repository.GetAsync(command.Id);
            data.City = command.City;
            data.Detail = command.Detail;
            data.District = command.District;
            data.UserId = command.UserId;
            await _repository.UpdateAsync(data);
        }
    }
}