namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class ToggleMovieStatusCommand
    {
        public int FilmID { get; set; }
    }
}