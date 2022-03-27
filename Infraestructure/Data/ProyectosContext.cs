namespace Infrastructure.Data;
public class ProyectosContext : DbContext {
    public ProyectosContext(DbContextOptions<ProyectosContext> options) : base(options) {

    }
    public DbSet<ProyectosContext> Proyectos { get; set; }
}

