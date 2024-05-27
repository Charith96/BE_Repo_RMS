using Microsoft.EntityFrameworkCore;
using conifs.rms.data;
using conifs.rms.data.repositories;
using conifs.rms.data.repositories.User;
using System.Collections.Generic;
using conifs.rms.business.managers;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();

// Register AutoMapper and scan for profiles in the assembly containing UserProfile
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

// Register your DbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
builder.Logging.AddConsole();

// Validate AutoMapper configuration
var serviceProvider = builder.Services.BuildServiceProvider();
var mapper = serviceProvider.GetRequiredService<IMapper>();
mapper.ConfigurationProvider.AssertConfigurationIsValid();

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

