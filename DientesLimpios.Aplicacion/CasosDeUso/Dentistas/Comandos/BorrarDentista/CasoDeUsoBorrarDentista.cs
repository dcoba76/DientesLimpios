using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.BorrarDentista;

public class CasoDeUsoBorrarDentista : IRequestHandler<ComandoBorrarDentista>
{
    private readonly IRepositorioDentistas _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoBorrarDentista(IRepositorioDentistas repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoBorrarDentista request)
    {
        var dentista = await _repositorio.ObtenerPorId(request.Id);
        if (dentista is null)
            throw new ExcepcionNoEncontrado();

        try
        {
            await _repositorio.Borrar(dentista);
            await _unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
