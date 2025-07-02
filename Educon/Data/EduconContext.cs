using Educon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Educon.Data;

public class EduconContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public EduconContext(DbContextOptions<EduconContext> options) : base(options)
    {
    }

    public DbSet<StudyField> StudyFields => Set<StudyField>();
    public DbSet<School> Schools => Set<School>();
    public DbSet<SchoolYear> SchoolYears => Set<SchoolYear>();
    public DbSet<ScheduleEntry> ScheduleEntries => Set<ScheduleEntry>();
    public DbSet<AttendanceRecord> AttendanceRecords => Set<AttendanceRecord>();
    public DbSet<TeacherSchoolAssignment> TeacherSchoolAssignments => Set<TeacherSchoolAssignment>();
    public DbSet<SchoolClass> SchoolClasses => Set<SchoolClass>();
    public DbSet<Profile> Profiles => Set<Profile>();
    public DbSet<GradeLevel> GradeLevels => Set<GradeLevel>();
    public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
    public DbSet<TeacherProfile> TeacherProfiles => Set<TeacherProfile>();
    public DbSet<ParentProfile> ParentProfiles => Set<ParentProfile>();
    public DbSet<StudentParent> StudentParents => Set<StudentParent>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<SubjectTeacher> SubjectTeachers => Set<SubjectTeacher>();
    public DbSet<Grade> Grades => Set<Grade>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentParent>()
            .HasKey(sp => new { sp.StudentId, sp.ParentId });

        modelBuilder.Entity<StudentParent>()
            .HasOne(sp => sp.Student)
            .WithMany(s => s.ParentsLinks)
            .HasForeignKey(sp => sp.StudentId);

        modelBuilder.Entity<StudentParent>()
            .HasOne(sp => sp.Parent)
            .WithMany(p => p.ChildrenLinks)
            .HasForeignKey(sp => sp.ParentId);

        modelBuilder.Entity<ApplicationUser>()
            .HasOne(u => u.Profile)
            .WithOne(p => p.User)
            .HasForeignKey<ApplicationUser>(u => u.ProfileId);
    }
}
