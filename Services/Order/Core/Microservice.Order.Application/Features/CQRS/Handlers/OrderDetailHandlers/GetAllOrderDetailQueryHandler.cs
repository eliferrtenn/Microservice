using Microservice.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Microservice.Order.Application.Interfaces;
using Microservice.Order.Domain.Entities;

namespace Microservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetAllOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetAllOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllOrderDetailQueryResult>> Handle()
        {
            var datas = await _repository.GetAllAsync();

            return datas.Select(x => new GetAllOrderDetailQueryResult
            {
                Id = x.Id,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductAmount = x.ProductAmount,
                ProductTotalPrice = x.ProductTotalPrice,
                OrderingId = x.OrderingId,
            }).ToList();
        }
    }
}
