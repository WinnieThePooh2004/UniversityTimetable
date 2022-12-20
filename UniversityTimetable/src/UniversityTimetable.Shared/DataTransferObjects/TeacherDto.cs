﻿using System.Text.Json.Serialization;
using UniversityTimetable.Shared.Enums;
using UniversityTimetable.Shared.Interfaces.Data;

namespace UniversityTimetable.Shared.DataTransferObjects
{
    public class TeacherDto : IDataTransferObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ScienceDegree ScienceDegree { get; set; }

        public int DepartmentId { get; set; }
        public List<SubjectDto> Subjects { get; set; } = new();
        [JsonIgnore] public string FullName => $"{FirstName[0]}. {LastName}";
    }
}