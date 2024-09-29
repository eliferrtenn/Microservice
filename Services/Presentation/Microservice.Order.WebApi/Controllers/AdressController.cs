using Microservice.Order.Application.Features.CQRS.Commands.AddressCommands;
using Microservice.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using Microservice.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AdressController : ControllerBase
    {
        private readonly GetAllAddressQueryHandler _getAllAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AdressController(GetAllAddressQueryHandler getAllAddressQueryHandler,
            GetAddressByIdQueryHandler getAddressByIdQueryHandler,
            CreateAddressCommandHandler createAddressCommandHandler,
            UpdateAddressCommandHandler updateAddressCommandHandler,
            RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAllAddressQueryHandler = getAllAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _getAllAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Kayıt başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DleeteAsync(Guid id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Kayıt başarıyla silindi");
        }
    }
}