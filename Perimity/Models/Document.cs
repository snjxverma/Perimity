using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perimity.Data;

public class Document
{
    [Key]
    public int DocumentId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    [StringLength(50)]
    public string DocumentType { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string FilePath { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string OriginalName { get; set; } = string.Empty;

    public long FileSize { get; set; }

    [Required]
    [StringLength(100)]
    public string MimeType { get; set; } = string.Empty;

    public bool Verified { get; set; } = false;

    public int? VerifiedBy { get; set; }

    [ForeignKey(nameof(VerifiedBy))]
    public ApplicationUser? VerifiedByUser { get; set; }

    public DateTime UploadedDate { get; set; } = DateTime.UtcNow;
}