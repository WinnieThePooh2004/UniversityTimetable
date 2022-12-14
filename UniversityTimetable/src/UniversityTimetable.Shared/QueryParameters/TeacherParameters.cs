using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Shared.QueryParameters;

public class TeacherParameters : QueryParameters, IQueryParameters<Teacher>
{
    public int DepartmentId { get; set; }
    public string? FirstName { get; set; }
}