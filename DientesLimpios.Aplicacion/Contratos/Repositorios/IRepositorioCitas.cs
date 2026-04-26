using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Dominio.Entidades;

namespace DientesLimpios.Aplicacion.Contratos.Repositorios;

public interface IRepositorioCitas : IRepositorio<Cita>
{

    new Task<Cita> ObtenerPorId(Guid Id);
    Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin);
    Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtroCitasDTO);
}
