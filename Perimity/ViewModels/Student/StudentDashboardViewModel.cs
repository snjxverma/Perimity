namespace Perimity.ViewModels.Student;

public class StudentDashboardViewModel
{
    public string FullName { get; set; } = string.Empty;

    public string RollNumber { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public byte Semester { get; set; }

    public byte Year { get; set; }

    public string ProfilePhoto { get; set; } = string.Empty;

    public int ProfileCompletionPercentage { get; set; }

    public bool IsApproved { get; set; }

    public string ApprovalStatus { get; set; } = "Pending";

    public bool CanViewQR { get; set; }

    public DateTime LastLogin { get; set; }
}