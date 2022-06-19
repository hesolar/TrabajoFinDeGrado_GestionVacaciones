namespace Infraestructure.Data; 
public class Context : DbContext {
  
    public Context(DbContextOptions<Context> options) : base(options) {

    }
    public DbSet<Core.Entities.CalendarioVacaciones> CalendarioVacaciones { get; set; }
    public DbSet<Core.Entities.Usuario> Usuarios { get; set; }
    public DbSet<Core.Entities.Roles> Roles { get; set; }
    public DbSet<Core.Entities.Proyecto> Proyectos { get; set; }
    public DbSet<Core.Entities.EstadoCalendarioVacaciones> EstadoCalendarioVacaciones { get; set; }
    public DbSet<Core.Entities.Employee> Employees { get; set; }
    public DbSet<Core.Entities.TipoDiaCalendario> TipoDiaCalendario { get; set; }
    public DbSet<Core.Entities.UsuarioProyecto> UsuarioProyecto { get; set; }
    public DbSet<Core.Entities.TecnicoProyectos> TecnicoProyectos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder) {
        //CalendarioVacaciones
        builder.Entity<Core.Entities.CalendarioVacaciones>().HasKey(table => new {
            table.IdTecnico,
            table.FechaCalendario
        });
        builder.Entity<Core.Entities.UsuarioProyecto>().HasKey(table => new {
            table.IdProyecto,
            table.IdTecnico
        });


    }


}
