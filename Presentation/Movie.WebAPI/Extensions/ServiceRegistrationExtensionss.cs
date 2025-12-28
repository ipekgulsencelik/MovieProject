using Movie.Application.Features.CQRS.Handlers.CategoryHandlers;
using Movie.Application.Features.CQRS.Handlers.MovieHandlers;
using Movie.Application.Features.CQRS.Handlers.SeriesHandlers;
using Movie.Application.Features.CQRS.Handlers.UserRegisterHandlers;

namespace Movie.WebAPI.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // CQRS Handlers - Category
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetActiveCategoriesQueryHandler>();
            services.AddScoped<GetVisibleCategoriesQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            services.AddScoped<HideCategoryCommandHandler>();
            services.AddScoped<ShowCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<ToggleCategoryStatusCommandHandler>();
            services.AddScoped<ArchiveCategoryCommandHandler>();
            services.AddScoped<UnarchiveCategoryCommandHandler>();
            services.AddScoped<SoftDeleteCategoryCommandHandler>();
            services.AddScoped<HardDeleteCategoryCommandHandler>();
            services.AddScoped<ApproveCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryStatusCommandHandler>();
            services.AddScoped<RejectCategoryCommandHandler>();

            // CQRS Handlers - Movie
            services.AddScoped<GetMovieQueryHandler>();
            services.AddScoped<GetActiveMoviesQueryHandler>();
            services.AddScoped<GetVisibleMoviesQueryHandler>();
            services.AddScoped<GetMovieByIdQueryHandler>();
            services.AddScoped<CreateMovieCommandHandler>();
            services.AddScoped<RemoveMovieCommandHandler>();
            services.AddScoped<HideMovieCommandHandler>();
            services.AddScoped<ShowMovieCommandHandler>();
            services.AddScoped<UpdateMovieCommandHandler>();
            services.AddScoped<ToggleMovieStatusCommandHandler>();

            // Series - Query Handlers
            services.AddScoped<GetSeriesQueryHandler>();
            services.AddScoped<GetSeriesByIdQueryHandler>();
            services.AddScoped<GetSeriesByCategoryQueryHandler>();
            services.AddScoped<GetPublishedSeriesQueryHandler>();
            services.AddScoped<GetPendingSeriesQueryHandler>();
            services.AddScoped<GetArchivedSeriesQueryHandler>();
            services.AddScoped<GetDeletedSeriesQueryHandler>();
            services.AddScoped<SearchSeriesQueryHandler>();

            // Series - Command Handlers
            services.AddScoped<CreateSeriesCommandHandler>();
            services.AddScoped<UpdateSeriesCommandHandler>();
            services.AddScoped<UpdateSeriesStatusCommandHandler>();
            services.AddScoped<ApproveSeriesCommandHandler>();
            services.AddScoped<RejectSeriesCommandHandler>();
            services.AddScoped<ToggleSeriesVisibilityCommandHandler>();
            services.AddScoped<ArchiveSeriesCommandHandler>();
            services.AddScoped<UnarchiveSeriesCommandHandler>();
            services.AddScoped<SoftDeleteSeriesCommandHandler>();
            services.AddScoped<HardDeleteSeriesCommandHandler>();
            services.AddScoped<RestoreSeriesCommandHandler>();

            // User Register
            services.AddScoped<CreateUserRegisterCommandHandler>();

            return services;
        }
    }
}