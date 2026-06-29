using Microsoft.AspNetCore.Identity;

namespace Perimity.Data;

public class ApplicationUser : IdentityUser<int>
{
    public string FullName { get; set; } = string.Empty;

    public string? ProfilePhoto { get; set; }

    public bool EmailVerified { get; set; } = false;

    public string ProfileStatus { get; set; } = "Pending";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public StudentProfile? StudentProfile { get; set; }

    public FacultyProfile? FacultyProfile { get; set; }

    public ICollection<Document> Documents { get; set; } = new List<Document>();

    public ICollection<OTPVerification> OTPVerifications { get; set; } = new List<OTPVerification>();

    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
}