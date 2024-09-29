using Microservice.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microservice.Order.Application.Features.CQRS.Results.AdressResults;
using Microservice.Order.Application.Interfaces;
using Microservice.Order.Domain.Entities;

namespace Microservice.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery result)
        {
            var data = await _repository.GetAsync(result.Id);

            return new GetAddressByIdQueryResult { 
                Id = data.Id,
                City = data.City,
                Detail =data.Detail,
                District = data.District,
                UserId = data.UserId,
            };
        }
    }
}