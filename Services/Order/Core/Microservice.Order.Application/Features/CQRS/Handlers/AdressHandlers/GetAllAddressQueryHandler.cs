using Microservice.Order.Application.Features.CQRS.Results.AdressResults;
using Microservice.Order.Application.Interfaces;
using Microservice.Order.Domain.Entities;

namespace Microservice.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAllAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAllAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAllAddressQueryResult>> Handle()
        {
            var datas = await _repository.GetAllAsync();

            return datas.Select(x => new GetAllAddressQueryResult
            {
                Id = x.Id,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId,
            }).ToList();
        }
    }
}