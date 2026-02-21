using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Comandos.CancelarCita;

public class CasoDeUsoCancelarCita: IRequestHandler<ComandoCancelarCita>
{
    private readonly IRepositorioCitas _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoCancelarCita(IRepositorioCitas repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoCancelarCita request)
    {
        var cita = await _repositorio.ObtenerPorId(request.Id);
        if (cita is null)
            throw new ExcepcionNoEncontrado();

        cita.Cancelar();

        try
        {
            await _repositorio.Actualizar(cita);
            await _unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
