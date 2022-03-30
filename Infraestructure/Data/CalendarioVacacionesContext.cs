namespace Infrastructure.Data;
public class CalendarioVacacionesContext : DbContext {
    public CalendarioVacacionesContext(DbContextOptions<CalendarioVacacionesContext> options) : base(options) {
    }
    public DbSet<Core.Entities.CalendarioVacaciones> CalendarioVacaciones { get; set; }


    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Core.Entities.CalendarioVacaciones>().HasKey(table => new {
            table.IdTecnico,
            table.FechaCalendario
        });
    }


}

