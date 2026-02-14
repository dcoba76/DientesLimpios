
using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios;

public interface IRepositorioDentistas: IRepositorio<Dentista>
{
    Task<IEnumerable<Dentista>> ObtenerFiltrado(FiltroDentistaDTO filtro);
}
