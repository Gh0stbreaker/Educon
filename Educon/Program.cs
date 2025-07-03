using Educon.Data;
using Educon.Models;
using Educon.Mappings;
using Educon.Repositories;
using Educon.Repositories.Interfaces;
using Educon.Repositories.Implementations;
using Educon.Services.Interfaces;
using Educon.Services.Implementations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddDbContext<EduconContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<EduconContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
builder.Services.AddScoped<IAttendanceRecordRepository, AttendanceRecordRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IGradeLevelRepository, GradeLevelRepository>();
builder.Services.AddScoped<IParentProfileRepository, ParentProfileRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IScheduleEntryRepository, ScheduleEntryRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<ISchoolYearRepository, SchoolYearRepository>();
builder.Services.AddScoped<IStudentParentRepository, StudentParentRepository>();
builder.Services.AddScoped<IStudentProfileRepository, StudentProfileRepository>();
builder.Services.AddScoped<IStudyFieldRepository, StudyFieldRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectTeacherRepository, SubjectTeacherRepository>();
builder.Services.AddScoped<ITeacherProfileRepository, TeacherProfileRepository>();
builder.Services.AddScoped<ITeacherSchoolAssignmentRepository, TeacherSchoolAssignmentRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
