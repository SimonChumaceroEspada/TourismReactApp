using Microsoft.EntityFrameworkCore;
using PlacesApi.Application.Services;
using PlacesApi.Domain.Interfaces;
using PlacesApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<PlacesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
builder.Services.AddScoped<ITouristicPlaceService, TouristicPlaceService>();
builder.Services.AddScoped<ITouristicPlaceRepository, TouristicPlaceRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IPartyService, PartyService>();
builder.Services.AddScoped<IPartyRepository, PartyRepository>();

// Add CORS Service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // React Application URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
