using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Aplicacion.Contratos.Repositorios.Modelos;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Dominio.ObjetosDeValor;
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

    public async Task<IEnumerable<Cita>> ObtenerFiltrado(FiltroCitasDTO filtroCitasDTO)
    {
        var queryable = _context.Citas
            .Include(x=> x.Paciente)
            .Include(x=> x.Dentista)
            .Include(x=> x.Consultorio)
            .AsQueryable();

        if(filtroCitasDTO.ConsultorioId is not null)
        {
            queryable = queryable.Where(x=> x.ConsultorioId == filtroCitasDTO.ConsultorioId);
        }

        if (filtroCitasDTO.PacienteId is not null)
        {
            queryable = queryable.Where(x => x.PacienteId == filtroCitasDTO.PacienteId);
        }

        if (filtroCitasDTO.DentistaId is not null)
        {
            queryable = queryable.Where(x => x.DentistaId == filtroCitasDTO.DentistaId);
        }

        if (filtroCitasDTO.EstadoCita is not null)
        {
            queryable = queryable.Where(x => x.Estado == filtroCitasDTO.EstadoCita);
        }

        return await queryable.Where(x => x.IntervaloDeTiempo.Inicio.Date >= filtroCitasDTO.Inicio.Date 
        && x.IntervaloDeTiempo.Fin.Date <= filtroCitasDTO.Fin.Date)
            .OrderBy(x => x.IntervaloDeTiempo.Inicio)
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
