using AutoMapper;
using Educon.Models;
using ProfileEntity = Educon.Models.Profile;

namespace Educon.Mappings;

public class AutoMapperProfile : AutoMapper.Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ApplicationUser, ApplicationUser>().ReverseMap();
        CreateMap<AttendanceRecord, AttendanceRecord>().ReverseMap();
        CreateMap<Grade, Grade>().ReverseMap();
        CreateMap<GradeLevel, GradeLevel>().ReverseMap();
        CreateMap<ParentProfile, ParentProfile>().ReverseMap();
        CreateMap<ProfileEntity, ProfileEntity>().ReverseMap();
        CreateMap<ScheduleEntry, ScheduleEntry>().ReverseMap();
        CreateMap<School, School>().ReverseMap();
        CreateMap<SchoolClass, SchoolClass>().ReverseMap();
        CreateMap<SchoolYear, SchoolYear>().ReverseMap();
        CreateMap<StudentParent, StudentParent>().ReverseMap();
        CreateMap<StudentProfile, StudentProfile>().ReverseMap();
        CreateMap<StudyField, StudyField>().ReverseMap();
        CreateMap<Subject, Subject>().ReverseMap();
        CreateMap<SubjectTeacher, SubjectTeacher>().ReverseMap();
        CreateMap<TeacherProfile, TeacherProfile>().ReverseMap();
        CreateMap<TeacherSchoolAssignment, TeacherSchoolAssignment>().ReverseMap();
    }
}
