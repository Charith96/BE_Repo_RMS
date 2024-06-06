using Microsoft.EntityFrameworkCore;
using conifs.rms.data;
using Microsoft.Extensions.DependencyInjection;

using conifs.rms.business.managers;
using conifs.rms.data.repositories.ReservationGroups;
using conifs.rms.data.repositories.ReservationItems;
using conifs.rms.data.repositories.TimeSlots;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
