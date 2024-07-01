
using conifs.rms.business.managers;
//using conifs.rms.contracts.Company;
using conifs.rms.data;
using conifs.rms.data.repositories;
using conifs.rms.data.repositories.Company;
using conifs.rms.data.repositories.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using conifs.rms.business.mappers;
using conifs.rms.data.Profiles;
using conifs.rms.business;
using conifs.rms.business.validators;
//using conifs.rms.dto.Company;


using conifs.rms.business.validations;
using conifs.rms.data.entities;

using FluentValidation;
using FluentValidation.AspNetCore;
using conifs.rms.data.entities;

using conifs.rms.data.repositories.ReservationGroups;
using conifs.rms.data.repositories.ReservationItems;
using conifs.rms.data.repositories.TimeSlots;
using conifs.rms.data.repositories.User;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
}); 

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("Role", "Admin"));
    options.AddPolicy("CanCreate", policy => policy.RequireAssertion(context =>
        context.User.HasClaim(claim => claim.Type == "Privileges" && claim.Value.Split(',').Contains("Create"))));
    options.AddPolicy("CanUpdate", policy => policy.RequireAssertion(context =>
        context.User.HasClaim(claim => claim.Type == "Privileges" && claim.Value.Split(',').Contains("Update"))));
    options.AddPolicy("CanDelete", policy => policy.RequireAssertion(context =>
        context.User.HasClaim(claim => claim.Type == "Privileges" && claim.Value.Split(',').Contains("Delete"))));
    options.AddPolicy("CanView", policy => policy.RequireAssertion(context =>
        context.User.HasClaim(claim => claim.Type == "Privileges" && claim.Value.Split(',').Contains("View"))));
});



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


builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryManager, CountryManager>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyManager, CurrencyManager>();
builder.Services.AddScoped<IAdminManager, AdminManager>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

//builder.Services.AddScoped<IValidator<Company>, CompanyValidator>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserManager, UserManager>();


// Register Reservation manager, repository, and validator

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<IReservationManager, ReservationManager>();


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
builder.Services.AddCors(options =>
{
    var frontendUrl = builder.Configuration.GetValue<string>("FrontendUrl");

    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
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
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
