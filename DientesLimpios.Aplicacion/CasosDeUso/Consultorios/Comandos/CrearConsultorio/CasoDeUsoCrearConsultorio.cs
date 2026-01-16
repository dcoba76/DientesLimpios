using DientesLimpios.Aplicacion.Contratos.Persistencia;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using DientesLimpios.Dominio.Entidades;
using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Comandos.CrearConsultorio;

public class CasoDeUsoCrearConsultorio: IRequestHandler<ComandoCrearConsultorio, Guid>
{
    private readonly IRepositorioConsultorios _repositorio;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;

    public CasoDeUsoCrearConsultorio(IRepositorioConsultorios repositorio, IUnidadDeTrabajo unidadDeTrabajo)
    {
        this._repositorio = repositorio;
        this._unidadDeTrabajo = unidadDeTrabajo;
    }
    public async Task<Guid> Handle(ComandoCrearConsultorio comando)
    {
        var consultorio = new Consultorio(comando.Nombre);

        try
        {
            var respuesta = await this._repositorio.Agregar(consultorio);
            await this._unidadDeTrabajo.Persistir();
            return respuesta.Id;
        }
        catch (Exception)
        {
            await this._unidadDeTrabajo.Reversar();
            throw; 
        }

        
    }
}
