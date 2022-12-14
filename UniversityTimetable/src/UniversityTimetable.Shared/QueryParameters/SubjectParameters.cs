﻿using UniversityTimetable.Shared.Extentions;
using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Shared.QueryParameters
{
    public class SubjectParameters : QueryParameters, IQueryParameters<Subject>
    {
        public int TeacherId { get; set; }

        public IQueryable<Subject> Filter(IQueryable<Subject> items)
            => items.Search(s => s.Name, SearchTerm).Where(s => TeacherId == 0 || s.TeacherIds.Any(t => t.TeacherId == TeacherId));
    }
}
