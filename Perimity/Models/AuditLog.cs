using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perimity.Data;

public class AuditLog
{
    [Key]
    public long LogId { get; set; }

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser? User { get; set; }

    [Required]
    [StringLength(100)]
    public string Action { get; set; } = string.Empty;

    [StringLength(100)]
    public string? EntityName { get; set; }

    [StringLength(100)]
    public string? EntityId { get; set; }

    [StringLength(50)]
    public string? IPAddress { get; set; }

    [StringLength(500)]
    public string? Browser { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}