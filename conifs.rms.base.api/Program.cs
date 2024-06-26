using Microsoft.EntityFrameworkCore;
using conifs.rms.data;
using conifs.rms.business;
using conifs.rms.business.validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using conifs.rms.data.entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});
// Register your repositories and managers
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleManager, RoleManager>();
builder.Services.AddScoped<IPrivilegeRepository, PrivilegeRepository>();
builder.Services.AddScoped<IPrivilegeManager, PrivilegeManager>();

// Register AutoMapper and scan for profiles in the assembly containing roleProfile
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Register the RoleValidator
builder.Services.AddScoped<IValidator<Role>, RoleValidation>();

// Register DbContext with SQL Server configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
