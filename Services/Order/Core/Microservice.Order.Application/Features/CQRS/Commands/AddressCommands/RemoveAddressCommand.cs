namespace Microservice.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public Guid Id { get; set; }

        public RemoveAddressCommand(Guid id)
        {
            Id = id;
        }
    }
}