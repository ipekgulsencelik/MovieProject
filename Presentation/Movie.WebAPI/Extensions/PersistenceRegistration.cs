using Microsoft.EntityFrameworkCore;
using Movie.Application.Interfaces;
using Movie.Persistence.Context;
using Movie.Persistence.Repositories;

namespace Movie.WebAPI.Extensions
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
                options.UseLazyLoadingProxies();
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISeriesRepository, SeriesRepository>();

            return services;
        }
    }
}