namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class ToggleMovieStatusCommand
    {
        public int FilmId { get; set; }
        
        public ToggleMovieStatusCommand(int filmId)
        {
            FilmId = filmId;
        }
    }
}