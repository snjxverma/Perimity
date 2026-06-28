using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Perimity.Models;

namespace Perimity.Data;

public class FacultyProfile
{
    [Key]
    public int FacultyId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    public int DepartmentId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; } = null!;

    [Required]
    [StringLength(30)]
    public string EmployeeId { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Designation { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Qualification { get; set; } = string.Empty;

    [StringLength(500)]
    public string? PhotoPath { get; set; }

    [StringLength(300)]
    public string? QRToken { get; set; }

    public DateTime? QRGeneratedAt { get; set; }

    public bool IsApprover { get; set; } = false;

    public int? ApprovedBy { get; set; }

    [ForeignKey(nameof(ApprovedBy))]
    public ApplicationUser? ApprovedByUser { get; set; }

    public DateTime? ApprovedDate { get; set; }
}
