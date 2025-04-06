using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.Mediator.Commands.CastCommands;
using Movie.Application.Features.Mediator.Queries.CastQueries;

namespace Movie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCastList()
        {
            var casts = await _mediator.Send(new GetCastQuery());
            return Ok(casts);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveCastList()
        {
            var casts = await _mediator.Send(new GetActiveCastQuery());
            return Ok(casts);
        }

        [HttpGet("visible")]
        public async Task<IActionResult> GetVisibleCastList()
        {
            var casts = await _mediator.Send(new GetVisibleCastQuery());
            return Ok(casts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Created Succesfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCast(int id)
        {
            await _mediator.Send(new RemoveCastCommand(id));
            return Ok("Deleted Succesfully");
        }

        [HttpPatch("show/{id}")]
        public async Task<IActionResult> ShowCast(int id)
        {
            await _mediator.Send(new ShowCastCommand(id));
            return Ok("Showed Succesfully");
        }

        [HttpPatch("hide/{id}")]
        public async Task<IActionResult> HideCast(int id)
        {
            await _mediator.Send(new HideCastCommand(id));
            return Ok("Hided Succesfully");
        }

        [HttpPatch("toggle-status/{id}")]
        public async Task<IActionResult> ToggleCastStatus(int id)
        {
            await _mediator.Send(new ToggleCastStatusCommand(id));
            return Ok("Status Updated Succesfully");
        }

        [HttpGet("GetCastById/{id}")]
        public async Task<IActionResult> GetCastById(int id)
        {
            var value = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand command)
        {
            await _mediator.Send(command);
            return Ok("Updated Succesfully");
        }
    }
}