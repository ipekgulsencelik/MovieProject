namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class UpdateMovieCommand
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}