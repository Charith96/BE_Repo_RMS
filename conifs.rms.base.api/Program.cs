
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
using conifs.rms.business.validators;
//using conifs.rms.dto.Company;






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryManager, CountryManager>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyManager, CurrencyManager>();
//builder.Services.AddScoped<IValidator<Company>, CompanyValidator>();


///////
builder.Services.AddAutoMapper(typeof(CompanyProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CountryProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CurrencyProfile).Assembly);

builder.Services.AddDbContext<CompanyDataContext>(options =>

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
