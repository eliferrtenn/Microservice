using Microservice.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Microservice.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using Microservice.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Microservice.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderDetailController : Controller
    {
        private readonly GetAllOrderDetailQueryHandler _getAllOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailController(GetAllOrderDetailQueryHandler getAllOrderDetailQueryHandler,
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler,
            RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getAllOrderDetailQueryHandler = getAllOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _getAllOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DleeteAsync(Guid id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}
