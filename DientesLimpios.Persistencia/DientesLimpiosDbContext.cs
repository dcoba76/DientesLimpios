using DientesLimpios.Aplicacion.Contratos.Identidad;
using DientesLimpios.Dominio.Comunes;
using DientesLimpios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace DientesLimpios.Persistencia;

public class DientesLimpiosDbContext:DbContext
{
    private readonly IServicioUsuarios _servicioUsuarios;

    public DientesLimpiosDbContext(DbContextOptions<DientesLimpiosDbContext> options,
        IServicioUsuarios servicioUsuarios): base(options)
    {
        this._servicioUsuarios = servicioUsuarios;
    }

    protected DientesLimpiosDbContext()
    {
        
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if(_servicioUsuarios is not null)
        {
            foreach(var entity in ChangeTracker.Entries<EntidadAuditable>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.FechaCreacion = DateTime.UtcNow;
                        entity.Entity.CreadoPor = _servicioUsuarios.ObtenerUsuarioId();
                        break;
                    case EntityState.Modified:
                        entity.Entity.UltimaFechaModificacion = DateTime.UtcNow;
                        entity.Entity.UltimaModificacionPor = _servicioUsuarios.ObtenerUsuarioId();
                        break;
                }
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DientesLimpiosDbContext).Assembly);
    }

    public DbSet<Consultorio> Consultorios { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Dentista> Dentistas { get; set; }
    public DbSet<Cita> Citas { get; set; }

}
