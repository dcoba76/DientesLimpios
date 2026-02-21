using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.BorrarCita;

public class CasoDeUsoBorrarCita: IRequestHandler<ComandoBorrarCita>
{
    private readonly IRepositorioCitas _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoBorrarCita(IRepositorioCitas repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoBorrarCita request)
    {
        var cita = await _repositorio.ObtenerPorId(request.Id);
        if (cita is null)
            throw new ExcepcionNoEncontrado();

        try
        {
            await _repositorio.Borrar(cita);
            await _unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
