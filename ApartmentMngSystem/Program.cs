using ApartmentMngSystem.Business.Application.CQRS.Handlers;
using ApartmentMngSystem.Business.Services.Abstract;
using ApartmentMngSystem.Business.Services.Concrete;
using ApartmentMngSystem.Core.Entities;
using ApartmentMngSystem.Core.TokenOperations.Dto;
using ApartmentMngSystem.DataAccess;
using ApartmentMngSystem.DataAccess.Repositories.Abstract;
using ApartmentMngSystem.DataAccess.Repositories.Concrete;
using ApartmentMngSystem.DataAccess.UnitOfWork;
using ApartmentMngSystem.Middleware;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Hangfire
builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddHangfireServer();

//DbContext
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
JwtTokenDefaults.JwtKey = builder.Configuration["JwtConfig:Key"];
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtTokenDefaults.ValidIssuer,
            ValidAudience = JwtTokenDefaults.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.JwtKey))
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Apartment Management", Version = "v1" });

    // JWT Yetkilendirmesi için Swagger Konfigürasyonu
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(RegisterUserCommandHandler).Assembly);

// Identity
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = false;
    opt.SignIn.RequireConfirmedPhoneNumber = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Services
builder.Services.AddScoped<ISendMailService, SendMailService>();
builder.Services.AddScoped<IApartmentCostService, ApartmentCostService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddScoped<CreditCardClientService, CreditCardClientService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Repositories
builder.Services.AddScoped<IApartmentCostRepository, ApartmentCostRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();

var app = builder.Build();

app.MapHangfireDashboard("/hangfire");

RecurringJob.AddOrUpdate<ISendMailService>("EmailJob", x => x.SendMail(), Cron.DayInterval(1));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Apartment API V1"));
    app.UseGlobalExceptionMiddleware(); // Geliþtirme ortamýnda burada çaðýr
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseGlobalExceptionMiddleware(); // Üretim ve diðer ortamlar için burada çaðýr
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();
app.Run();