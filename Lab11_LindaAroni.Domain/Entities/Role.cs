using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab11_LindaAroni.Domain.Entities;

[Table("roles")]
[Index("RoleName", Name = "role_name", IsUnique = true)]
public partial class Role
{
    [Key]
    [Column("role_id")]
    public Guid RoleId { get; set; }

    [Column("role_name")]
    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
