namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class ShowMovieCommand
    {
        public int FilmId { get; set; }

        public ShowMovieCommand(int filmId)
        {
            FilmId = filmId;
        }
    }
}