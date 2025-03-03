namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class ToggleMovieStatusCommand
    {
        public ToggleMovieStatusCommand(int filmID)
        {
            FilmID = filmID;
        }

        public int FilmID { get; set; }
    }
}