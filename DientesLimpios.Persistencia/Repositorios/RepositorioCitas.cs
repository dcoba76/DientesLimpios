using DientesLimpios.Aplicacion.CasosDeUso.Citas.Consultas.ObtenerListadoCitas;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios;

public class RepositorioCitas: Repositorio<Cita>, IRepositorioCitas
{
    private readonly DientesLimpiosDbContext _context;

    public RepositorioCitas(DientesLimpiosDbContext context): base(context)
    {
        _context = context;
    }

    public async Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin)
    {
        return await _context.Citas
            .Where(x=> x.DentistaId == dentistaId && x.Estado == Dominio.Enums.EstadoCita.Programada && 
            inicio < x.IntervaloDeTiempo.Fin && 
            fin > x.IntervaloDeTiempo.Inicio).AnyAsync();
    }

    public async Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtro)
    {
        var queryable = _context.Citas
            .Include(x=> x.Paciente)
            .Include(x=> x.Dentista)
            .Include(x=> x.Consultorio)
            .AsQueryable();

        if(filtro.ConsultorioId is not null)
        {
            queryable = queryable.Where(x=> x.ConsultorioId == filtro.ConsultorioId);
        }

        if (filtro.PacienteId is not null)
        {
            queryable = queryable.Where(x => x.PacienteId == filtro.PacienteId);
        }

        if (filtro.DentistaId is not null)
        {
            queryable = queryable.Where(x => x.DentistaId == filtro.DentistaId);
        }

        if (filtro.EstadoCita is not null)
        {
            queryable = queryable.Where(x => x.Estado == filtro.EstadoCita);
        }

        return await queryable
            .Where(x => x.IntervaloDeTiempo.Inicio.Date >= filtro.Inicio.Date && x.IntervaloDeTiempo.Fin.Date <= filtro.Fin.Date)
            .OrderBy(x => x.IntervaloDeTiempo.Inicio)
            .Paginar(filtro.Pagina, filtro.RegistrosPorPagina)
            .ToListAsync();

    }

    new public async Task<Cita?> ObtenerPorId(Guid Id)
    {
        return await _context.Citas
            .Include(x => x.Paciente)
            .Include(x => x.Dentista)
            .Include(x => x.Consultorio)
            .FirstOrDefaultAsync(x => x.Id == Id); 
    }
}
