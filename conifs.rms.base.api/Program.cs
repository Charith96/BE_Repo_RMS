using Microsoft.EntityFrameworkCore;
using conifs.rms.data;
using conifs.rms.business;
using conifs.rms.business.validations;
using conifs.rms.data.entities;
using FluentValidation.AspNetCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        // Register validators from the assembly containing RoleValidation
        fv.RegisterValidatorsFromAssemblyContaining<RoleValidation>();
    });

// Register FluentValidation validators
builder.Services.AddScoped<IValidator<Role>, RoleValidation>();

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        // Register validators from the assembly containing PrivilegeValidation
        fv.RegisterValidatorsFromAssemblyContaining<PrivilegeValidation>();
    });

// Register FluentValidation validators
builder.Services.AddScoped<IValidator<Privilege>, PrivilegeValidation>();

// Register your repositories and managers
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleManager, RoleManager>();
builder.Services.AddScoped<IPrivilegeRepository, PrivilegeRepository>();
builder.Services.AddScoped<IPrivilegeManager, PrivilegeManager>();

// Register the DbContext with the connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
