namespace Infrastructure.Data;
public class TecnicoProyectosContext : DbContext {
    public TecnicoProyectosContext(DbContextOptions<TecnicoProyectosContext> options) : base(options) {

    }
    public DbSet<TecnicoProyectosContext> TecnicoProyectos { get; set; }
}
