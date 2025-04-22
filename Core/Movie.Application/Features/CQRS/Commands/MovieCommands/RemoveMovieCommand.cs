namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class RemoveMovieCommand
    {
        public int FilmId { get; set; }

        public RemoveMovieCommand(int filmId)
        {
            FilmId = filmId;
        }
    }
}