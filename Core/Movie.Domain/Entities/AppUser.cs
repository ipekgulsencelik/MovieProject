﻿using Microsoft.AspNetCore.Identity;

namespace Movie.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ImageUrl { get; set; }
    }
}