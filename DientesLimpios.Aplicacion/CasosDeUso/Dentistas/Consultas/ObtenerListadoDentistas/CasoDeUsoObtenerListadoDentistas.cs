namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas;

using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

public class CasoDeUsoObtenerListadoDentistas: IRequestHandler<ConsultaObtenerListadoDentistas, List<DentistaListadoDTO>>
{
    private readonly IRepositorioDentistas _repositorio;

    public CasoDeUsoObtenerListadoDentistas(IRepositorioDentistas repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<List<DentistaListadoDTO>> Handle(ConsultaObtenerListadoDentistas request)
    {
        var dentistas = await _repositorio.ObtenerTodos();
        return dentistas.Select(d => d.ADto()).ToList();
    }
}
