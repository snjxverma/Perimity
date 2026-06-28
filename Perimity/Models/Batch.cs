using Perimity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perimity.Models
{
    public enum AdmissionMonth
    {
        February = 1,
        August = 2
    }

    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        [Required]
        [StringLength(20)]
        public string BatchCode { get; set; } = string.Empty;
        // FEB-2026

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; } = null!;

        [Required]
        public AdmissionMonth AdmissionMonth { get; set; }

        [Required]
        public int AdmissionYear { get; set; }

        [Required]
        public DateTime CourseStartDate { get; set; }

        [Required]
        public DateTime CourseEndDate { get; set; }

        [Required]
        public DateTime PlacementStartDate { get; set; }

        [Required]
        public DateTime QRValidTill { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<StudentProfile> StudentProfiles { get; set; }
            = new List<StudentProfile>();
    }
}
