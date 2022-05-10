using ApiRest.Context;
using ApiRest.Entities;
using ApiRest.Mapper;
using ApiRest.Repository;
using ApiRest.Service;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("MariaDB");
builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseLazyLoadingProxies().UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

// Add Repositories
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<CamareroRepository>();
builder.Services.AddScoped<CocineroRepository>();
builder.Services.AddScoped<GerenteRepository>();

// Add Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<CamareroService>();
builder.Services.AddScoped<CocineroService>();
builder.Services.AddScoped<GerenteService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(UsuarioMapper),
    typeof(CamareroMapper),
    typeof(CocineroMapper),
    typeof(GerenteMapper),
    typeof(CategoriaMapper),
    typeof(ComandaMapper),
    typeof(MesaMapper),
    typeof(PedidoMapper),
    typeof(ProductoMapper),
    typeof(ReservaMapper));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();