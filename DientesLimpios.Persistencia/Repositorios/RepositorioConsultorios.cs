using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios;

public class RepositorioConsultorios: Repositorio<Consultorio>, IRepositorioConsultorios
{
    private readonly DientesLimpiosDbContext _context;

    public RepositorioConsultorios(DientesLimpiosDbContext context): base(context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Dentista>> ObtenerFiltrado(FiltroConsultorioDTO filtro)
    {
        var queryable = _context.Dentistas.AsQueryable();

        if (!string.IsNullOrEmpty(filtro.Nombre))
        {
            queryable = queryable.Where(x => x.Nombre.Contains(filtro.Nombre));
        }




        return await queryable.OrderBy(x => x.Nombre)
            .Paginar(filtro.Pagina, filtro.RegistrosPorPagina).ToListAsync();
    }
}
