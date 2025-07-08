using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab11_LindaAroni.Domain.Entities;

[Table("users")]
[Index("Email", Name = "email", IsUnique = true)]
[Index("Username", Name = "username", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("username")]
    [StringLength(100)]
    public string Username { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column("email")]
    [StringLength(150)]
    public string? Email { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Responder")]
    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();

    [InverseProperty("User")]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    [InverseProperty("User")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
