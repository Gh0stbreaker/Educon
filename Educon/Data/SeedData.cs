using Educon.Models;
using Microsoft.EntityFrameworkCore;

namespace Educon.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<EduconContext>();
        context.Database.Migrate();

        if (!context.GradeLevels.Any())
        {
            context.GradeLevels.AddRange(
                new GradeLevel { Id = Guid.NewGuid(), Name = "1. ročník" },
                new GradeLevel { Id = Guid.NewGuid(), Name = "2. ročník" },
                new GradeLevel { Id = Guid.NewGuid(), Name = "3. ročník" },
                new GradeLevel { Id = Guid.NewGuid(), Name = "4. ročník" }
            );
        }

        if (!context.StudyFields.Any())
        {
            context.StudyFields.AddRange(
                new StudyField { Id = Guid.NewGuid(), Code = "01", Name = "Informatika", Type = StudyFieldType.Technical },
                new StudyField { Id = Guid.NewGuid(), Code = "02", Name = "Matematika", Type = StudyFieldType.Technical }
            );
        }

        if (!context.Subjects.Any())
        {
            context.Subjects.AddRange(
                new Subject { Id = Guid.NewGuid(), Name = "Matematika" },
                new Subject { Id = Guid.NewGuid(), Name = "Český jazyk" },
                new Subject { Id = Guid.NewGuid(), Name = "Informatika" }
            );
        }

        if (!context.Schools.Any())
        {
            context.Schools.Add(new School
            {
                Id = Guid.NewGuid(),
                Name = "Testovací škola",
                Address = "Ulice 123, Město",
                Type = SchoolType.Secondary,
                Level = SchoolLevel.Second,
                Status = SchoolStatus.State
            });
        }

        if (!context.SchoolYears.Any())
        {
            context.SchoolYears.Add(new SchoolYear
            {
                Id = Guid.NewGuid(),
                Name = "2024/2025",
                StartDate = new DateTime(2024, 9, 1),
                EndDate = new DateTime(2025, 6, 30)
            });
        }

        await context.SaveChangesAsync();
    }
}
