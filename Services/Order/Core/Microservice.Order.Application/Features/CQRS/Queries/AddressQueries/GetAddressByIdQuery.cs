namespace Microservice.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public Guid Id { get; set; }

        public GetAddressByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}