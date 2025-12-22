using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movie.Application.Features.CQRS.Handlers.CategoryHandlers;
using Movie.Application.Features.CQRS.Handlers.MovieHandlers;
using Movie.Application.Features.CQRS.Handlers.UserRegisterHandlers;
using Movie.Application.Features.Mediator.Handlers.TagHandlers;
using Movie.Application.Interfaces;
using Movie.Application.Validators;
using Movie.Domain.Entities;
using Movie.Persistence.Context;
using Movie.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));

builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    options.UseLazyLoadingProxies();
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));

// CQRS Handlers
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
builder.Services.AddScoped<ArchiveCategoryCommandHandler>();
builder.Services.AddScoped<UnarchiveCategoryCommandHandler>();
builder.Services.AddScoped<SoftDeleteCategoryCommandHandler>();
builder.Services.AddScoped<HardDeleteCategoryCommandHandler>();
builder.Services.AddScoped<ApproveCategoryCommandHandler>();

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

builder.Services.AddScoped<CreateUserRegisterCommandHandler>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MovieContext>().AddErrorDescriber<CustomErrorDescriber>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();