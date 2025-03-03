namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class ShowMovieCommand
    {
        public ShowMovieCommand(int filmID)
        {
            FilmID = filmID;
        }

        public int FilmID { get; set; }
    }
}