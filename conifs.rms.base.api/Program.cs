
using conifs.rms.business.managers;
//using conifs.rms.contracts.Company;
using conifs.rms.data;
using conifs.rms.data.repositories;
using conifs.rms.data.repositories.Company;
using Microsoft.EntityFrameworkCore;
using conifs.rms.dto.Company;
using AutoMapper;
//using conifs.rms.business.mappers;
using conifs.rms.data.Profiles;
using conifs.rms.business;
//using conifs.rms.dto.Company;

using conifs.rms.business;
using conifs.rms.business.validations;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.data.Profiles;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using conifs.rms.business.managers;
using conifs.rms.data.repositories.ReservationGroups;
using conifs.rms.data.repositories.ReservationItems;
using conifs.rms.data.repositories.TimeSlots;







var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQL Server configuration


builder.Services.AddControllers();
       
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("CorsPolicy",
//        builder => builder.WithOrigins("http://localhost:3005")
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials());
//});

builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryManager, CountryManager>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyManager, CurrencyManager>();


///////
builder.Services.AddAutoMapper(typeof(CompanyProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CountryProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CurrencyProfile).Assembly);
// Register your repositories and managers
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleManager, RoleManager>();
builder.Services.AddScoped<IPrivilegeRepository, PrivilegeRepository>();
builder.Services.AddScoped<IPrivilegeManager, PrivilegeManager>();

// Register the RoleValidator
builder.Services.AddScoped<IValidator<Role>, RoleValidation>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);

builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//builder.Services.AddFluentValidation(fv =>
//{
    // Register validators from the assembly containing CustomerValidation
//    fv.RegisterValidatorsFromAssemblyContaining<CustomerValidation>();
//});

// Register FluentValidation validators
builder.Services.AddScoped<IValidator<Customer>, CustomerValidation>();



builder.Services.AddScoped<IReservationGroupManager, ReservationGroupManager>();
builder.Services.AddScoped<IReservationGroupRepository, ReservationGroupRepository>();
builder.Services.AddScoped<IReservationItemManager, ReservationItemManager>();
builder.Services.AddScoped<IReservationItemRepository, ReservationItemRepository>();
builder.Services.AddScoped<ITimeSlotManager, TimeSlotManager>();
builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



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
