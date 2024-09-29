namespace Microservice.Order.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailByIdQueryResult
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public double ProductTotalPrice { get; set; }
        public Guid OrderingId { get; set; }
    }
}