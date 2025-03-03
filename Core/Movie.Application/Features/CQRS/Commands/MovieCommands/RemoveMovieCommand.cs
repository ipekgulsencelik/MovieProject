namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class RemoveMovieCommand
    {
        public RemoveMovieCommand(int filmID)
        {
            FilmID = filmID;
        }

        public int FilmID { get; set; }
    }
}