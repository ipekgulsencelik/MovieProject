using Microsoft.AspNetCore.Mvc;
using Movie.Application.Features.CQRS.Commands.CategoryCommands;
using Movie.Application.Features.CQRS.Commands.MovieCommands;
using Movie.Application.Features.CQRS.Handlers.CategoryHandlers;
using Movie.Application.Features.CQRS.Handlers.MovieHandlers;
using Movie.Application.Features.CQRS.Queries.MovieQueries;

namespace Movie.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly ToggleMovieStatusCommandHandler _toggleMovieStatusCommandHandler;
        private readonly ShowMovieCommandHandler _showMovieCommandHandler;
        private readonly HideMovieCommandHandler _hideMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly GetActiveMoviesQueryHandler _getActiveMoviesQueryHandler;
        private readonly GetVisibleMoviesQueryHandler _getVisibleMoviesQueryHandler;

        public MoviesController(CreateMovieCommandHandler createMovieCommandHandler, GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, ToggleMovieStatusCommandHandler toggleMovieStatusCommandHandler, HideMovieCommandHandler hideMovieCommandHandler, ShowMovieCommandHandler showMovieCommandHandler, GetVisibleMoviesQueryHandler getVisibleMoviesQueryHandler, GetActiveMoviesQueryHandler getActiveMoviesQueryHandler)
        {
            _createMovieCommandHandler = createMovieCommandHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _showMovieCommandHandler = showMovieCommandHandler;
            _hideMovieCommandHandler = hideMovieCommandHandler;
            _toggleMovieStatusCommandHandler = toggleMovieStatusCommandHandler;
            _getActiveMoviesQueryHandler = getActiveMoviesQueryHandler;
            _getVisibleMoviesQueryHandler = getVisibleMoviesQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovieList()
        {
            var movies = await _getMovieQueryHandler.Handle();
            return Ok(movies);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveMovieList()
        {
            var movies = await _getActiveMoviesQueryHandler.Handle();
            return Ok(movies);
        }

        [HttpGet("visible")]
        public async Task<IActionResult> GetVisibleMovieList()
        {
            var movies = await _getVisibleMoviesQueryHandler.Handle();
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Film Bilgisi Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Silme işlemi başarılı!");
        }

        [HttpPatch("show/{id}")]
        public async Task<IActionResult> ShowMovie(int id)
        {
            await _showMovieCommandHandler.Handle(new ShowMovieCommand(id));
            return Ok("Movie is visible");
        }

        [HttpPatch("hide/{id}")]
        public async Task<IActionResult> HideMovie(int id)
        {
            await _hideMovieCommandHandler.Handle(new HideMovieCommand(id));
            return Ok("Movie is hidden");
        }

        [HttpPatch("toggle-status/{id}")]
        public async Task<IActionResult> ToggleMovieStatus(int id)
        {
            await _toggleMovieStatusCommandHandler.Handle(new ToggleMovieStatusCommand(id));
            return Ok("Movie status updated");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı!");
        }

        [HttpGet("GetMovie")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var value = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(value);
        }
    }
}