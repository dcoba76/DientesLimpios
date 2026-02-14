using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Comandos.CrearDentista;

public class CasoDeUsoCrearDentista: IRequestHandler<ComandoCrearDentista, Guid>
{
    private readonly IRepositorioDentistas _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoCrearDentista(IRepositorioDentistas repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        _repositorio = repositorio;
        _unidadDeTrabajo = unidadDeTrabajo;
    }

    public async Task<Guid> Handle(ComandoCrearDentista request)
    {
        var dentista = new Dentista(request.Nombre, new Email(request.Email));

        try
        {
            var respuesta = await _repositorio.Agregar(dentista);
            await _unidadDeTrabajo.Persistir();
            return respuesta.Id;
        }
        catch (Exception)
        {
            await _unidadDeTrabajo.Reversar();
            throw;
        }
    }
}
