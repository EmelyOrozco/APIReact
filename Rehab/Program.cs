using Microsoft.EntityFrameworkCore;
using Rehab.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
string connectionString = builder.Configuration.GetConnectionString("con");
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
builder.Services.AddDbContext<RehabContext>(db => db.UseSqlServer(connectionString));

var app = builder.Build();


app.UseCors(options => options.AllowAnyHeader()
                             .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                          .AllowCredentials());

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
