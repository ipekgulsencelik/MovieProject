using Microsoft.OpenApi.Models;

namespace Movie.WebAPI.Extensions
{
    public static class SwaggerRegistration
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie API", Version = "v1" });
            });

            return services;
        }
    }
}