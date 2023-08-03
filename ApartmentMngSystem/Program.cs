using ApartmentMngSystem.Business.Application.CQRS.Handlers;
using ApartmentMngSystem.Business.Tools;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.DataAccess;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using ApartmentMngSystem.DataAccess.Repositories.Concrete;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
JwtTokenDefaults.JwtKey = builder.Configuration["JwtConfig:Key"];  // JwtKey'yi doðru deðerle dolduruyoruz

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.JwtKey)),  // Burada JwtKey'yi kullanýyoruz
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
    };
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(RegisterUserCommandHandler).Assembly);


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();