namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class HideMovieCommand
    {
        public int FilmId { get; set; }

        public HideMovieCommand(int filmId)
        {
            FilmId = filmId;
        }
    }
}