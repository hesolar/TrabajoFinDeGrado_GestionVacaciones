namespace Infrastructure.Data;
public class UsuariosContext : DbContext {
    public UsuariosContext(DbContextOptions<UsuariosContext> options) : base(options) {

    }
    public DbSet<Core.Entities.Usuario> Usuarios { get; set; }
}

