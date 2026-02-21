using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;

public class CasoDeUsoObtenerListadoCitas: IRequestHandler<ConsultaObtenerListadoCitas, List<CitaListadoDTO>>
{
    private readonly IRepositorioCitas _repositorio;

    public CasoDeUsoObtenerListadoCitas(IRepositorioCitas repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<CitaListadoDTO>> Handle(ConsultaObtenerListadoCitas request)
    {
        var citas = await _repositorio.ObtenerFiltrado(request);
        var citasdto = citas.Select(c => c.ADto()).ToList();
        return citasdto;
    }
}
