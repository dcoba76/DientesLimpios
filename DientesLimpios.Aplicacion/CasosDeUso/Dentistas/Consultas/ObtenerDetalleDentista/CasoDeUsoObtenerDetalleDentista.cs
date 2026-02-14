using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Excepciones;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerDetalleDentista;

public class CasoDeUsoObtenerDetalleDentista : IRequestHandler<ConsultaObtenerDetalleDentista, DentistaDetalleDTO>
{
    private readonly IRepositorioDentistas _repositorioDentistas;

    public CasoDeUsoObtenerDetalleDentista(IRepositorioDentistas repositorioDentistas)
    {
        this._repositorioDentistas = repositorioDentistas;
    }
    public async Task<DentistaDetalleDTO> Handle(ConsultaObtenerDetalleDentista request)
    {
        var dentista = await _repositorioDentistas.ObtenerPorId(request.Id);
        if(dentista is null)
        {
            throw new ExcepcionNoEncontrado();
        }
        return dentista.ADto();
    }
}
