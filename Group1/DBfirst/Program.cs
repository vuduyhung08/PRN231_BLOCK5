using DBfirst.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;

namespace DBfirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var modelBuilder = new ODataConventionModelBuilder();
            builder.Services.AddControllers().AddOData(opt => opt
                .Select()
                .Expand()
                .Filter()
                .OrderBy()
                .Count()
                .SetMaxTop(100)
            .AddRouteComponents("odata", modelBuilder.GetEdmModel())
            );
            builder.Services.AddDbContext<BL5_PRN231_ProjectContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
