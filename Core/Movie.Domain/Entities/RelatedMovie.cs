﻿namespace Movie.Domain.Entities
{
    public class RelatedMovie
    {
        public int RelatedMovieId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public bool IsWatched { get; set; }
    }
}