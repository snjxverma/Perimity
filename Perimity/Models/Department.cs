using System.ComponentModel.DataAnnotations;
using Perimity.Data;

namespace Perimity.Models;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }

    [Required]
    [StringLength(100)]
    public string DepartmentName { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string DepartmentCode { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<StudentProfile> StudentProfiles { get; set; } = new List<StudentProfile>();

    public ICollection<FacultyProfile> FacultyProfiles { get; set; } = new List<FacultyProfile>();
}