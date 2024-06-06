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
//using conifs.rms.dto.Company;

//using ICompanyRepository = conifs.rms.data.repositories.Company.ICompanyRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICompanyManager, CompanyManager>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();


///////
builder.Services.AddAutoMapper(typeof(CompanyProfile).Assembly);

//var automapper = new MapperConfiguration(item => item.AddProfile(new CompanyMappers()));
//IMapper mapper = automapper.CreateMapper();

//builder.Services.AddSingleton(mapper);
///////

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAuthorization();

app.MapControllers();

app.Run();
