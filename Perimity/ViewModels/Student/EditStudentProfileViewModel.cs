using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Perimity.ViewModels.Student;

public class EditStudentProfileViewModel
{
    [Required]
    [StringLength(500)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string ParentName { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string ParentContact { get; set; } = string.Empty;

    public IFormFile? Photo { get; set; }

    public IFormFile? AadhaarDocument { get; set; }
}