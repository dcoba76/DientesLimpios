using DientesLimpios.API.Middlewares;
using DientesLimpios.Aplicacion;
using DientesLimpios.Persistencia;
using DientesLimpios.Infraestructura;
using DientesLimpios.API.Jobs;
using DientesLimpios.Identidad;
using DientesLimpios.Identidad.Modelos;
using Microsoft.AspNetCore.Mvc.Authorization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter("esadmin"));
});

builder.Services.AgregarServiciosDeAplicacion();
builder.Services.AgregarServiciosDePersistencia();
builder.Services.AgregarServiciosDeInfraestructura();
builder.Services.AgregarServiciosDeIdentidad(builder.Configuration);

builder.Services.AddHostedService<RecordatorioCitaJob>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapIdentityApi<Usuario>();

app.UseManejadorExcepciones();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
