using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Perimity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<StudentProfile> StudentProfiles { get; set; }
    public DbSet<FacultyProfile> FacultyProfiles { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<OTPVerification> OTPVerification { get; set; }
    public DbSet<Attendance> Attendance { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Department>().ToTable("Departments");
        builder.Entity<StudentProfile>().ToTable("StudentProfiles");
        builder.Entity<FacultyProfile>().ToTable("FacultyProfiles");
        builder.Entity<Document>().ToTable("Documents");
        builder.Entity<OTPVerification>().ToTable("OTPVerification");
        builder.Entity<Attendance>().ToTable("Attendance");
        builder.Entity<AuditLog>().ToTable("AuditLogs");

        builder.Entity<Department>()
            .HasIndex(d => d.DepartmentName)
            .IsUnique();

        builder.Entity<Department>()
            .HasIndex(d => d.DepartmentCode)
            .IsUnique();

        builder.Entity<StudentProfile>()
            .HasIndex(s => s.UserId)
            .IsUnique();

        builder.Entity<StudentProfile>()
            .HasIndex(s => s.RollNumber)
            .IsUnique();

        builder.Entity<StudentProfile>()
            .HasIndex(s => s.QRToken)
            .IsUnique();

        builder.Entity<FacultyProfile>()
            .HasIndex(f => f.UserId)
            .IsUnique();

        builder.Entity<FacultyProfile>()
            .HasIndex(f => f.EmployeeId)
            .IsUnique();

        builder.Entity<FacultyProfile>()
            .HasIndex(f => f.QRToken)
            .IsUnique();

        builder.Entity<Attendance>()
            .HasIndex(a => new { a.UserId, a.ScanDate })
            .IsUnique()
            .HasDatabaseName("IX_Attendance_User_Date");

        builder.Entity<StudentProfile>()
            .HasOne(s => s.User)
            .WithOne(u => u.StudentProfile)
            .HasForeignKey<StudentProfile>(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<StudentProfile>()
            .HasOne(s => s.ApprovedByUser)
            .WithMany()
            .HasForeignKey(s => s.ApprovedBy)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<StudentProfile>()
            .HasOne(s => s.Department)
            .WithMany(d => d.StudentProfiles)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<FacultyProfile>()
            .HasOne(f => f.User)
            .WithOne(u => u.FacultyProfile)
            .HasForeignKey<FacultyProfile>(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<FacultyProfile>()
            .HasOne(f => f.ApprovedByUser)
            .WithMany()
            .HasForeignKey(f => f.ApprovedBy)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<FacultyProfile>()
            .HasOne(f => f.Department)
            .WithMany(d => d.FacultyProfiles)
            .HasForeignKey(f => f.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Document>()
            .HasOne(d => d.User)
            .WithMany(u => u.Documents)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Document>()
            .HasOne(d => d.VerifiedByUser)
            .WithMany()
            .HasForeignKey(d => d.VerifiedBy)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<OTPVerification>()
            .HasOne(o => o.User)
            .WithMany(u => u.OTPVerifications)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Attendance>()
            .HasOne(a => a.User)
            .WithMany(u => u.Attendances)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Attendance>()
            .HasOne(a => a.Guard)
            .WithMany()
            .HasForeignKey(a => a.ScannedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<AuditLog>()
            .HasOne(a => a.User)
            .WithMany(u => u.AuditLogs)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}