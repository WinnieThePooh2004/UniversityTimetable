﻿using UniversityTimetable.Shared.Extensions;
using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Shared.QueryParameters
{
    public class DepartmentParameters : QueryParameters, IQueryParameters<Department>
    {
        public int FacultacyId { get; set; }
        public string DepartmentName { get; set; }
    }
}
