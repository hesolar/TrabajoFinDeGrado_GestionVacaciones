namespace Infrastructure.Data;
public class CalendarioVacacionesContext : DbContext {
    public CalendarioVacacionesContext(DbContextOptions<CalendarioVacacionesContext> options) : base(options) {
    }
    public DbSet<Core.Entities.CalendarioVacaciones> CalendarioVacaciones { get; set; }
}

