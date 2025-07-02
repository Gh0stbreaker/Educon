namespace Educon.Models;

public enum RelationshipType
{
    Father,
    Mother,
    Guardian,
    Foster,
    Institution,
    Other
}

public enum TeacherType
{
    Main,
    Substitute,
    Assistant,
    Consultant,
    External
}

public enum TeacherStatus
{
    Active,
    OnLeave,
    Retired,
    Terminated,
    Suspended,
    ContractEnded
}

public enum StudentType
{
    Regular,
    Exchange,
    Distance,
    Other
}

public enum StudentStatus
{
    Active,
    Suspended,
    Graduated,
    Withdrawn,
    Expelled,
    OnLeave
}

public enum StudentNeedType
{
    None,
    SpecialNeeds,
    Gifted,
    LearningDisability,
    LanguageSupport,
    Other
}

public enum SubjectType
{
    Compulsory,
    Elective,
    Optional,
    Remedial,
    Extracurricular
}

public enum ClassType
{
    Standard,
    SpecialEducation,
    Advanced,
    Remedial,
    Preparatory,
    Other
}

public enum SchoolType
{
    Elementary,
    Secondary,
    HighSchool,
    Vocational,
    SpecialEducation,
    Other
}

public enum SchoolLevel
{
    First,
    Second,
    Third,
    Other
}

public enum SchoolStatus
{
    State,
    Private,
    Church,
    Other
}

public enum StudyFieldType
{
    General,
    Technical,
    Vocational,
    Art,
    Sports,
    Other
}
