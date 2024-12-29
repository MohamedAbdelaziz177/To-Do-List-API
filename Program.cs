
using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;
using ToDoListApi.Repositories;

namespace ToDoListApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseMySql(builder.Configuration.GetConnectionString("CS"),
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.1.0-mysql"))
                 );

            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
