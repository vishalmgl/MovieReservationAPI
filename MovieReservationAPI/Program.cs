using Microsoft.EntityFrameworkCore; // Required for EF Core
using MovieReservationAPI.Data; // Namespace for AppDbContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // Register controllers for API endpoints

// Register AppDbContext for Entity Framework Core
// Using SQL Server with connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Enable Swagger UI in development mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Use Authorization middleware (if needed)
app.UseAuthorization();

// Map controllers to handle API requests
app.MapControllers();

app.Run();
