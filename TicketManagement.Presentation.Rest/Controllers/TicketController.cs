using Framework.Application.Command;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Application.Contracts.Commands;

namespace TicketManagement.Presentation.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public TicketController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public IActionResult Post(RegisterTicket command)
        {
            _commandBus.Dispatch(command);
            return Ok();
        }
    }
}