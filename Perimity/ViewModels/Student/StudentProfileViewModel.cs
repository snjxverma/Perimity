namespace Perimity.ViewModels.Student
{
    public class StudentProfileViewModel
    {
        public int StudentId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string RollNumber { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        public byte Year { get; set; }

        public byte Semester { get; set; }

        public string Address { get; set; } = string.Empty;

        public string? ParentName { get; set; }

        public string? ParentContact { get; set; }

        public string? PhotoPath { get; set; }

        public bool IsApproved { get; set; }

        public string ApprovalStatus { get; set; } = "Pending";

        public bool CanViewQR { get; set; }

        public int ProfileCompletionPercentage { get; set; }
    }
}
