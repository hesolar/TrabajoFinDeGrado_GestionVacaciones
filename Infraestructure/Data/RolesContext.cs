namespace Infrastructure.Data;
public class RolesContext : DbContext {
    public RolesContext(DbContextOptions<RolesContext> options) : base(options) {

    }
    public DbSet<Core.Entities.Roles> Roles { get; set; }
}
