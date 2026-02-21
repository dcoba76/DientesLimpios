using DientesLimpios.Aplicacion.Contratos.Identidad;
using DientesLimpios.Identidad.Modelos;
using DientesLimpios.Identidad.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Identidad;

public static class RegistroDeServiciosDeIdentidad
{
    public static void AgregarServiciosDeIdentidad(this IServiceCollection servicios, IConfiguration configuracion)
    {
        servicios.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);

        servicios.AddAuthorization(opciones =>
        {
            opciones.AddPolicy("esadmin", politica => politica.RequireClaim("esadmin"));
        });

        servicios.AddDbContext<DientesLimpiosIdentityDbContext>(options =>
            options.UseSqlServer(configuracion.GetConnectionString("DientesLimpiosConnectionString")));
        
        servicios.AddIdentityCore<Usuario>()
            .AddEntityFrameworkStores<DientesLimpiosIdentityDbContext>()
            .AddApiEndpoints();

        servicios.AddTransient<IServicioUsuarios, ServicioUsuarios>();
        servicios.AddHttpContextAccessor();
    }
}
