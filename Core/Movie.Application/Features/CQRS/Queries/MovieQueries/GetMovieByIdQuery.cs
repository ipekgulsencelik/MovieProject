namespace Movie.Application.Features.CQRS.Queries.MovieQueries
{
    public class GetMovieByIdQuery
    {
        public GetMovieByIdQuery(int filmID)
        {
            FilmID = filmID;
        }

        public int FilmID { get; set; }
    }
}