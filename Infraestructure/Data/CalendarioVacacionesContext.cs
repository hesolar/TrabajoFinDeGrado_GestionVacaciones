namespace Infrastructure.Data;
public class CalendarioVacacionesContext : DbContext {
    public CalendarioVacacionesContext(DbContextOptions<CalendarioVacacionesContext> options) : base(options) {
    }
    public DbSet<Usuario> CalendarioVacaciones { get; set; }
}

