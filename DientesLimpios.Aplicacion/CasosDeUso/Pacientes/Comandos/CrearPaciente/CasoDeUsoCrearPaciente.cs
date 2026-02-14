using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Comandos.CrearPaciente;

public class CasoDeUsoCrearPaciente : IRequestHandler<CommandoCrearPaciente, Guid>
{
    private readonly IRepositorioPacientes _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoCrearPaciente(IRepositorioPacientes repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        this._repositorio = repositorio;
        this._unidadDeTrabajo = unidadDeTrabajo;
    }
    public async Task<Guid> Handle(CommandoCrearPaciente request)
    {
        var email =  new Email(request.Email);
        var paciente = new Paciente(request.Nombre, email);
        try
        {
            var respuesta = await _repositorio.Agregar(paciente);
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
