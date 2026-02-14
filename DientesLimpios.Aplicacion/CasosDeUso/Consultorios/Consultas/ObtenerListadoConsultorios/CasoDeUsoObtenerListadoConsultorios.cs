using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;

public class CasoDeUsoObtenerListadoConsultorios: IRequestHandler<ConsultaObtenerListadoConsultorios, 
                                                                  List<ConsultorioListadoDTO>>
{
    private readonly IRepositorioConsultorios _repositorio;

    public CasoDeUsoObtenerListadoConsultorios(IRepositorioConsultorios repositorio)
    {
        this._repositorio = repositorio;
    }

    public async Task<List<ConsultorioListadoDTO>> Handle(ConsultaObtenerListadoConsultorios request)
    {
        var consultorios = await _repositorio.ObtenerTodos();
        var consultoriosDTO = consultorios.Select(c => new ConsultorioListadoDTO
        {
            Id = c.Id,
            Nombre = c.Nombre
        }).ToList();

        return consultoriosDTO;
    }
}
