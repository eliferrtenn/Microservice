﻿namespace Microservice.Order.Domain.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public double ProductTotalPrice { get; set; }
        public Guid OrderingId { get; set; }
        public Ordering Ordering { get; set; }
    }
}