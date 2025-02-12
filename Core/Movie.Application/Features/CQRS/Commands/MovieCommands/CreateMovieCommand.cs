﻿namespace Movie.Application.Features.CQRS.Commands.MovieCommands
{
    public class CreateMovieCommand
    {
        public string? Title { get; set; }
        public string? CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string? Description { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}