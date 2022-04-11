namespace Infrastructure.Data;
public class TipoDiaCalendarioContext : DbContext {

    public TipoDiaCalendarioContext(DbContextOptions<TipoDiaCalendarioContext> options) : base(options) {

    }
    public DbSet<Core.Entities.TipoDiaCalendario> TipoDiaCalendario { get; set; }
}
