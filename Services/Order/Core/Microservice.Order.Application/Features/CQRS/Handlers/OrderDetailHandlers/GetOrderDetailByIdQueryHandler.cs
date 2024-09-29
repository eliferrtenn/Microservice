using Microservice.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microservice.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Microservice.Order.Application.Features.CQRS.Results.AdressResults;
using Microservice.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Microservice.Order.Application.Interfaces;
using Microservice.Order.Domain.Entities;

namespace Microservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery result)
        {
            var data = await _repository.GetAsync(result.Id);

            return new GetOrderDetailByIdQueryResult
            {
                Id = data.Id,
                ProductId = data.ProductId,
                ProductName = data.ProductName,
                ProductPrice = data.ProductPrice,
                ProductAmount = data.ProductAmount,
                ProductTotalPrice = data.ProductTotalPrice,
                OrderingId = data.OrderingId,
            };
        }
    }
}
