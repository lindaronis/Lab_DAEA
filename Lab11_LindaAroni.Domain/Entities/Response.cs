using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lab11_LindaAroni.Domain.Entities;

[Table("responses")]
[Index("ResponderId", Name = "responder_id")]
[Index("TicketId", Name = "ticket_id")]
public partial class Response
{
    [Key]
    [Column("response_id")]
    public Guid ResponseId { get; set; }

    [Column("ticket_id")]
    public Guid TicketId { get; set; }

    [Column("responder_id")]
    public Guid ResponderId { get; set; }

    [Column("message", TypeName = "text")]
    public string Message { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("ResponderId")]
    [InverseProperty("Responses")]
    public virtual User Responder { get; set; } = null!;

    [ForeignKey("TicketId")]
    [InverseProperty("Responses")]
    public virtual Ticket Ticket { get; set; } = null!;
}
