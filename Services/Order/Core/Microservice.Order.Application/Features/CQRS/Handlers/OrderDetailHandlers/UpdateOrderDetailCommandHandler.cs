using Microservice.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Microservice.Order.Application.Interfaces;
using Microservice.Order.Domain.Entities;

namespace Microservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var data = await _repository.GetAsync(command.Id);
            data.ProductId = command.ProductId;
            data.ProductName = command.ProductName;
            data.ProductPrice = command.ProductPrice;
            data.ProductAmount = command.ProductAmount;
            data.ProductTotalPrice = command.ProductTotalPrice;
            data.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(data);
        }
    }
}