//using Microsoft.EntityFrameworkCore;
//using conifs.rms.data;
//using conifs.rms.business;
//using conifs.rms.business.validations;
//using conifs.rms.data.entities;
//using conifs.rms.dto.Role;
//using FluentValidation.AspNetCore;
//using FluentValidation;
//using AutoMapper;
//using conifs.rms.data.Profile;
//using Microsoft.AspNetCore.Identity;

//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Register AutoMapper
//builder.Services.AddAutoMapper(typeof(RoleProfile));



// Add services to the container.
//builder.Services.AddControllers()
  //  .AddFluentValidation(fv =>
    //{
        // Register validators from the assembly containing RoleValidation
      //  fv.RegisterValidatorsFromAssemblyContaining<RoleValidation>();
    //});

// Register FluentValidation validators
//builder.Services.AddScoped<IValidator<Role>, RoleValidation>();

// Add services to the container.
//builder.Services.AddControllers()
  //  .AddFluentValidation(fv =>
    //{
        // Register validators from the assembly containing PrivilegeValidation
      //  fv.RegisterValidatorsFromAssemblyContaining<PrivilegeValidation>();
    //});

// Register FluentValidation validators
//builder.Services.AddScoped<IValidator<Privilege>, PrivilegeValidation>();

// Register your repositories and managers
//builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//builder.Services.AddScoped<IRoleManager, RoleManager>();
//builder.Services.AddScoped<IPrivilegeRepository, PrivilegeRepository>();
//builder.Services.AddScoped<IPrivilegeManager, PrivilegeManager>();

// Register the DbContext with the connection string
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
  //  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
  //  app.UseSwagger();
    //app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();





using conifs.rms.business.managers;
//using conifs.rms.contracts.Company;
using conifs.rms.data;
using conifs.rms.data.repositories;
using conifs.rms.data.repositories.Company;
using Microsoft.EntityFrameworkCore;

//using conifs.rms.business.mappers;
using conifs.rms.data.Profiles;
using conifs.rms.business;
//using conifs.rms.dto.Company;


using conifs.rms.business.validations;
using conifs.rms.data.entities;

using FluentValidation;
using FluentValidation.AspNetCore;

using conifs.rms.data.repositories.ReservationGroups;
using conifs.rms.data.repositories.ReservationItems;
using conifs.rms.data.repositories.TimeSlots;
using conifs.rms.data.repositories.User;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;







var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();

// Register DbContext with SQL Server configuration



// Other service configurations...


// Other service configurations...

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryManager, CountryManager>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyManager, CurrencyManager>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();


// Register AutoMapper and scan for profiles in the assembly containing UserProfile
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
