using conifs.rms.business;
using conifs.rms.data;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using conifs.rms.business.validations;
using conifs.rms.data.entities;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        // Register validators from the assembly containing CustomerValidation
        fv.RegisterValidatorsFromAssemblyContaining<CustomerValidation>();
    });

// Register FluentValidation validators
builder.Services.AddScoped<IValidator<Customer>, CustomerValidation>();



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

app.UseAuthorization();

app.MapControllers();

app.Run();
