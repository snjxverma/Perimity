using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Perimity.Models;

namespace Perimity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Batch> Batches { get; set; }
    public DbSet<StudentProfile> StudentProfiles { get; set; }
    public DbSet<FacultyProfile> FacultyProfiles { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<OTPVerification> OTPVerifications { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    // Exact table names
    builder.Entity<Course>().ToTable("Courses");
    builder.Entity<Batch>().ToTable("Batches");
    builder.Entity<StudentProfile>().ToTable("StudentProfiles");
    builder.Entity<FacultyProfile>().ToTable("FacultyProfiles");
    builder.Entity<Document>().ToTable("Documents");
    builder.Entity<OTPVerification>().ToTable("OTPVerifications");
    builder.Entity<Attendance>().ToTable("Attendances");
    builder.Entity<AuditLog>().ToTable("AuditLogs");

    // Unique fields
    builder.Entity<Course>()
        .HasIndex(c => c.CourseName)
        .IsUnique();

    builder.Entity<Course>()
        .HasIndex(c => c.CourseCode)
        .IsUnique();

    builder.Entity<Batch>()
        .HasIndex(b => b.BatchCode)
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

    // StudentProfile -> ApplicationUser
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

    // StudentProfile -> Batch
    builder.Entity<StudentProfile>()
        .HasOne(s => s.Batch)
        .WithMany(b => b.StudentProfiles)
        .HasForeignKey(s => s.BatchId)
        .OnDelete(DeleteBehavior.Restrict);

    // FacultyProfile -> ApplicationUser
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

    // FacultyProfile -> Course
    builder.Entity<FacultyProfile>()
        .HasOne(f => f.Course)
        .WithMany(c => c.FacultyProfiles)
        .HasForeignKey(f => f.CourseId)
        .OnDelete(DeleteBehavior.Restrict);

    // Batch -> Course
    builder.Entity<Batch>()
        .HasOne(b => b.Course)
        .WithMany(c => c.Batches)
        .HasForeignKey(b => b.CourseId)
        .OnDelete(DeleteBehavior.Restrict);

    // Document -> ApplicationUser
    // User = document owner
    builder.Entity<Document>()
        .HasOne(d => d.User)
        .WithMany(u => u.Documents)
        .HasForeignKey(d => d.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    // VerifiedByUser = admin who verified document
    builder.Entity<Document>()
        .HasOne(d => d.VerifiedByUser)
        .WithMany()
        .HasForeignKey(d => d.VerifiedBy)
        .OnDelete(DeleteBehavior.SetNull);

    // OTPVerification -> ApplicationUser
    builder.Entity<OTPVerification>()
        .HasOne(o => o.User)
        .WithMany(u => u.OTPVerifications)
        .HasForeignKey(o => o.UserId)
        .OnDelete(DeleteBehavior.Cascade);

    // Attendance -> ApplicationUser
    // User = student/faculty whose QR was scanned
    builder.Entity<Attendance>()
        .HasOne(a => a.User)
        .WithMany(u => u.Attendances)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.Restrict);

    // Guard = guard who scanned QR
    builder.Entity<Attendance>()
        .HasOne(a => a.Guard)
        .WithMany()
        .HasForeignKey(a => a.ScannedBy)
        .OnDelete(DeleteBehavior.Restrict);

    // AuditLog -> ApplicationUser
    builder.Entity<AuditLog>()
        .HasOne(a => a.User)
        .WithMany(u => u.AuditLogs)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.SetNull);
}
}