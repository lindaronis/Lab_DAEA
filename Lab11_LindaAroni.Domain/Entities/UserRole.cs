
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab11_LindaAroni.Domain.Entities;

[PrimaryKey("UserId", "RoleId")]
[Table("user_roles")]
[Index("RoleId", Name = "role_id")]
public partial class UserRole
{
    [Key]
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Key]
    [Column("role_id")]
    public Guid RoleId { get; set; }

    [Column("assigned_at", TypeName = "timestamp")]
    public DateTime? AssignedAt { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("UserRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UserRoles")]
    public virtual User User { get; set; } = null!;
}
