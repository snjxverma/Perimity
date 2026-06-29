using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perimity.Data;

public class OTPVerification
{
    [Key]
    public int OTPId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    [StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string OTP { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string Purpose { get; set; } = "Registration";

    public DateTime ExpiryTime { get; set; }

    public bool IsUsed { get; set; } = false;

    public byte Attempts { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}