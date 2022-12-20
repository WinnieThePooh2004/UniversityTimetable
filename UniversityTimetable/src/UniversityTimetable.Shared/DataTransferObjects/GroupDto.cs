﻿using UniversityTimetable.Shared.Interfaces.Data;

namespace UniversityTimetable.Shared.DataTransferObjects
{
    public class GroupDto : IDataTransferObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}