using Movie.Application.Validators;
using Movie.Domain.Entities;
using Movie.Persistence.Context;

namespace Movie.WebAPI.Extensions
{
    public static class IdentityRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<MovieContext>()
                    .AddErrorDescriber<CustomErrorDescriber>();

            return services;
        }
    }
}