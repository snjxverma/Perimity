using System.ComponentModel.DataAnnotations;
using Perimity.Data;

namespace Perimity.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    [StringLength(100)]
    public string CourseName { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string CourseCode { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<Batch> Batches { get; set; } = new List<Batch>();

    public ICollection<FacultyProfile> FacultyProfiles { get; set; } = new List<FacultyProfile>();
}