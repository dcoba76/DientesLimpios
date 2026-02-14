using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.ActualizarDentista;

public class CasoDeUsoActualizarDentista : IRequestHandler<ComandoActualizarDentista>
{
    private readonly IRepositorioDentistas _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoActualizarDentista(IRepositorioDentistas repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task Handle(ComandoActualizarDentista request)
    {
        var dentista = await _repositorio.ObtenerPorId(request.Id);
        if (dentista is null)
            throw new ExcepcionNoEncontrado();

        dentista.ActualizarNombre(request.Nombre);
        dentista.ActualizarEmail(new Email(request.Email));

        try
        {
            await _repositorio.Actualizar(dentista);
            await _unidadDeTrabajo.Persistir();
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
