namespace Infrastructure.Data;

public class EstadoCalendarioVacacionesContext : DbContext{
    public EstadoCalendarioVacacionesContext(DbContextOptions<EstadoCalendarioVacacionesContext> options) : base(options) {

    }
    public DbSet<Core.Entities.EstadoCalendarioVacaciones> EstadoCalendarioVacaciones { get; set; }

}
