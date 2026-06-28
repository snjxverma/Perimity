using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perimity.Data;

public class Attendance
{
    [Key]
    public int AttendanceId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string Role { get; set; } = string.Empty;

    public DateTime ScanDate { get; set; }

    public TimeSpan ScanTime { get; set; }

    [Required]
    public int ScannedBy { get; set; }

    [ForeignKey(nameof(ScannedBy))]
    public ApplicationUser Guard { get; set; } = null!;

    [StringLength(300)]
    public string? Device { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}