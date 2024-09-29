﻿namespace Microservice.Order.Application.Features.CQRS.Results.AdressResults
{
    public class GetAddressByIdQueryResult
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}