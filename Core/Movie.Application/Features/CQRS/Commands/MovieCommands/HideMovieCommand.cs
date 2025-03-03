namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class HideMovieCommand
    {
        public HideMovieCommand(int filmID)
        {
            FilmID = filmID;
        }

        public int FilmID { get; set; }
    }
}