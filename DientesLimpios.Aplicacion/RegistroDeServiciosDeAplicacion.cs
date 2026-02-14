using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.ActualizarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.BorrarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerDetalleConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.Extensions.DependencyInjection;

namespace DientesLimpios.Aplicacion;

public static class RegistroDeServiciosDeAplicacion
{
    public static IServiceCollection AgregarServiciosDeAplicacion(this IServiceCollection servicios)
    {
        // Aquí se registran los servicios específicos de la capa de aplicación
        servicios.AddTransient<IMediator, MediadorSimple>();

        servicios.Scan(scan =>
        scan.FromAssembliesOf(typeof(IMediator))
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        //servicios.AddScoped<IRequestHandler<ComandoCrearConsultorio, Guid>, CasoDeUsoCrearConsultorio>();
        //servicios.AddScoped<IRequestHandler<ComandoActualizarConsultorio>, CasoDeUsoActualizarConsultorio>();
        //servicios.AddScoped<IRequestHandler<ComandoBorrarConsultorio>, CasoDeUsoBorrarConsultorio>();
        //servicios.AddScoped<IRequestHandler<ConsultaObtenerDetalleConsultorio, ConsultorioDetalleDTO>, CasoDeUsoObtenerDetalleConsultorio> ();
        //servicios.AddScoped<IRequestHandler<ConsultaObtenerListadoConsultorios, List<ConsultorioListadoDTO>>, CasoDeUsoObtenerListadoConsultorios>();

        return servicios;
    }
}
