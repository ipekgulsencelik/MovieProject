using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.CQRS.Commands.UserRegisterCommands;
using Movie.Application.Features.CQRS.Handlers.UserRegisterHandlers;

namespace Movie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistersController : ControllerBase
    {
        private readonly CreateUserRegisterCommandHandler _handler; 

        public UserRegistersController(CreateUserRegisterCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRegister(CreateUserRegisterCommand command)
        {
            await _handler.Handle(command);
            return Ok("Kullanıcı başarıyla eklendi.");
        }
    }
}