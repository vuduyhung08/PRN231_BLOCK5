using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.OData.ModelBuilder;
using DBfirst.Configurations;
using DBfirst.DataAccess;
using DBfirst.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Teacher>("Teachers");
    builder.EntitySet<Subject>("Subjects");

    // Register the action
    var action = builder.EntityType<Teacher>().Action("ChangeSubject");
    action.Parameter<int>("subjectId");
    action.Returns<IActionResult>();

    return builder.GetEdmModel();
}

builder.Services.AddControllers()
    .AddOData(options => options.Select().Filter().OrderBy().Expand().SetMaxTop(100)
    .AddRouteComponents("odata", GetEdmModel())
    .Count());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Project_B5DBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);

var tokenValidationParameter = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false,
    RequireExpirationTime = false,
    ValidateLifetime = true
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = tokenValidationParameter;
    });
builder.Services.AddSingleton(tokenValidationParameter);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<Project_B5DBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


