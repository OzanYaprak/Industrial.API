
using Industrial.API.Data;
using Industrial.API.Services.Abstract;
using Industrial.API.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Industrial.API
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


            //AUTOMAPPER LINE
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //SQL CONNECTION LINE
            builder.Services.AddDbContext<IndustrialDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
            //CUSTOM 
            builder.Services.AddScoped<ICategoryService,CategoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}