namespace Infrastructure.Data;
public class RolesContext : DbContext {
    public RolesContext(DbContextOptions<RolesContext> options) : base(options) {

    }
    public DbSet<ProyectosContext> Roles { get; set; }
}
