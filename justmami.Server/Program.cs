
using justmami.Application.Users.Commands.AddUser;
using justmami.Domain.Entities;
using justmami.Infrastructure.Core;
using justmami.Infrastructure.Repositories;

namespace justmami.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        _ = builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen();

        //DDD
        _ = builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<AddUserCommand>());

        //Repositories
        _ = builder.Services.AddScoped<IRepository<User>, UserRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }

        _ = app.UseHttpsRedirection();

        _ = app.UseAuthorization();

        _ = app.MapControllers();

        app.Run();
    }
}
