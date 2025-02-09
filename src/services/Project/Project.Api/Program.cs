using Project.Api.Exceptions;
using Project.Application;
using Project.Infrastructure;
using FluentValidation.AspNetCore;
using Project.Application.Features.Project.Commands;
using Project.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationRegisteration();
builder.Services.AddInfrastructureRegisteration(builder.Configuration);
builder.Services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssembly(typeof(CreateProjectCommand).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ProjectDbContext>();
        if (dbContext.Database.GetMigrations().Any())
            dbContext.Database.Migrate();
    }
    catch (Exception)
    {
    }
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();


app.Run();
