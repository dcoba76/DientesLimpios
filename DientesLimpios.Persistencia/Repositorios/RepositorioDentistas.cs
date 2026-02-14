using DientesLimpios.Aplicacion.CasosDeUso.Dentistas.Consultas.ObtenerListadoDentistas;
using DientesLimpios.Aplicacion.CasosDeUso.Pacientes.Consultas.ObtenerListadoPacientes;
using DientesLimpios.Aplicacion.Contratos.Repositorios;
using DientesLimpios.Dominio.Entidades;
using DientesLimpios.Persistencia.Utilidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia.Repositorios;

public class RepositorioDentistas: Repositorio<Dentista>, IRepositorioDentistas
{
    private readonly DientesLimpiosDbContext _context;

    public RepositorioDentistas(DientesLimpiosDbContext context): base(context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Dentista>> ObtenerFiltrado(FiltroDentistaDTO filtro)
    {
        var queryable = _context.Dentistas.AsQueryable();

        if (!string.IsNullOrEmpty(filtro.Nombre))
        {
            queryable = queryable.Where(x => x.Nombre.Contains(filtro.Nombre));
        }

        if (!string.IsNullOrEmpty(filtro.Email))
        {
            queryable = queryable.Where(x => x.Email.Valor.Contains(filtro.Email));
        }



        return await queryable.OrderBy(x => x.Nombre)
            .Paginar(filtro.Pagina, filtro.RegistrosPorPagina).ToListAsync();
    }
}
