using Microsoft.EntityFrameworkCore;
using Movie.Application.Features.CQRS.Handlers.CategoryHandlers;
using Movie.Application.Features.CQRS.Handlers.MovieHandlers;
using Movie.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    options.UseLazyLoadingProxies();
});

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetActiveCategoriesQueryHandler>();
builder.Services.AddScoped<GetVisibleCategoriesQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<HideCategoryCommandHandler>();
builder.Services.AddScoped<ShowCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<ToggleCategoryStatusCommandHandler>();

builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<GetActiveMoviesQueryHandler>();
builder.Services.AddScoped<GetVisibleMoviesQueryHandler>();
builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();
builder.Services.AddScoped<HideMovieCommandHandler>();
builder.Services.AddScoped<ShowMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();
builder.Services.AddScoped<ToggleMovieStatusCommandHandler>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
