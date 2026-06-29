using Perimity.Models;
using Perimity.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perimity.Data;

public class StudentProfile
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public ApplicationUser User { get; set; } = null!;

    [Required]
    [StringLength(20)]
    public string RollNumber { get; set; } = string.Empty;

    //[Required]
    //public byte Year { get; set; }

    //[Required]
    //public byte Semester { get; set; }

    [Required]
    public int BatchId { get; set; }

    [ForeignKey(nameof(BatchId))]
    public Batch Batch { get; set; } = null!;

    [Required]
    [StringLength(12)]
    public string AadhaarNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(300)]
    public string Address { get; set; } = string.Empty;

    [StringLength(150)]
    public string? ParentName { get; set; }

    [StringLength(15)]
    public string? ParentContact { get; set; }

    [StringLength(500)]
    public string? PhotoPath { get; set; }

    [StringLength(500)]
    public string? AadhaarDocPath { get; set; }

    [StringLength(300)]
    public string? QRToken { get; set; }

    public DateTime? QRGeneratedAt { get; set; }

    public int? ApprovedBy { get; set; }
    public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Pending;

    [ForeignKey(nameof(ApprovedBy))]
    public ApplicationUser? ApprovedByUser { get; set; }

    public DateTime? ApprovedDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}