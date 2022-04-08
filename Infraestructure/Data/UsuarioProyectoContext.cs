namespace Infrastructure.Data;
public class UsuarioProyectoContext : DbContext {
    public UsuarioProyectoContext(DbContextOptions<UsuarioProyectoContext> options) : base(options) {
    }
    public DbSet<Core.Entities.UsuarioProyecto> UsuarioProyecto { get; set; }


    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Core.Entities.UsuarioProyecto>().HasKey(table => new {
            table.IdProyecto,
            table.IdTecnico
        });
    }


}

