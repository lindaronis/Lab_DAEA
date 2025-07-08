using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab11_LindaAroni.Domain.Entities;

[Table("tickets")]
[Index("UserId", Name = "user_id")]
public partial class Ticket
{
    [Key]
    [Column("ticket_id")]
    public Guid TicketId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("status", TypeName = "enum('abierto','en_proceso','cerrado')")]
    public string Status { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [Column("closed_at", TypeName = "timestamp")]
    public DateTime? ClosedAt { get; set; }

    [InverseProperty("Ticket")]
    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();

    [ForeignKey("UserId")]
    [InverseProperty("Tickets")]
    public virtual User User { get; set; } = null!;
}
