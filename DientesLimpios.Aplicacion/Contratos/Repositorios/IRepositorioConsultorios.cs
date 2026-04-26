using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios;

public interface IRepositorioConsultorios: IRepositorio<Consultorio>
{
    Task<IEnumerable<Dentista>> ObtenerFiltrado(FiltroConsultorioDTO filtro);
}
