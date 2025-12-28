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
using Movie.WebAPI.Extensions;
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
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ISeriesRepository, SeriesRepository>();

// CQRS Handlers
builder.Services.AddApplicationServices();

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

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger/index.html");
        return;
    }

    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();