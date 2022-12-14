using AutoMapper;
using UniversityTimetable.Domain.Mapping.Converters;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Models;

namespace UniversityTimetable.Domain.Mapping;

public class GroupProfile : Profile
{
    public GroupProfile() 
    {
        CreateMap<Group, GroupDto>().ReverseMap();
        this.CreateListWithPaginationDataMap<Group, GroupDto>();
    }
}