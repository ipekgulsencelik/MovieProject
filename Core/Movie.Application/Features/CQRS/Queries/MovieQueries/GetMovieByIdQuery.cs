namespace Movie.Application.Features.CQRS.Queries.MovieQueries
{
    public class GetMovieByIdQuery
    {
        public int FilmId { get; set; }

        public GetMovieByIdQuery(int filmId)
        {
            FilmId = filmId;
        }
    }
}