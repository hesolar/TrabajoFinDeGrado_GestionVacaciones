namespace Infrastructure.Data;
public class ProyectosContext : DbContext {
    public ProyectosContext(DbContextOptions<ProyectosContext> options) : base(options) {

    }
    public DbSet<Core.Entities.Proyecto> Proyectos { get; set; }
}

