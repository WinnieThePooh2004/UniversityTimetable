﻿using AutoMapper;
using UniversityTimetable.Domain.Mapping.Converters;
using UniversityTimetable.Shared.DataContainers;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Extentions;
using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Domain.Mapping
{
    public class ClassProfile : Profile
    {
        public ClassProfile()
        {
            CreateMap<Class, ClassDTO>();
            CreateMap<ClassDTO, Class>()
                .IgnoreMember(dest => dest.Group)
                .IgnoreMember(dest => dest.Auditory)
                .IgnoreMember(dest => dest.Teacher)
                .IgnoreMember(dest => dest.Subject);

            CreateMap<TimetableData, Timetable>().ConvertUsing<TimetableConvert>();
        }
    }
}
