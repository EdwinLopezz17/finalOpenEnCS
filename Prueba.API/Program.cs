using Microsoft.EntityFrameworkCore;
using Prueba.Domain;
using Prueba.Domain.Interfaces;
using Prueba.Domain.Mapping;
using Prueba.Domain.Mapping.Response;
using Prueba.Infraestructure;
using Prueba.Infraestructure.Context;
using Prueba.Infraestructure.Interfaces;
using Prueba.Infraestructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IProductInfrastructure, ProductInfraestructure>();
builder.Services.AddScoped<ISnapshotInfrastructure, SnapshotInfrastructure>();
builder.Services.AddScoped<IProductDomain, ProductDomain>();
builder.Services.AddScoped<ISnapshotDomain, SnapshotDomain>();
builder.Services.AddAutoMapper(
    typeof(ModelToResponse), 
    typeof(RequestToModel)
    
    );


// MySQL Connection
var connectionString = builder.Configuration.GetConnectionString("PruebaConnection");

builder.Services.AddDbContext<PruebaDBContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });


var app = builder.Build();

// Create database if not exists
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<PruebaDBContext>())
{
    context.Database.EnsureCreated();
}

//Cors
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


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