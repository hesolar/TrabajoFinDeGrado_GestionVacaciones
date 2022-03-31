namespace Core.Entities;
public class Roles {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Rol { get; set; }
}
