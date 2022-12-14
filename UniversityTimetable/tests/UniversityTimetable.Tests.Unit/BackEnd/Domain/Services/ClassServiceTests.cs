using AutoMapper;
using Microsoft.Extensions.Logging;
using UniversityTimetable.Domain.Services;
using UniversityTimetable.Shared.DataContainers;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Exceptions.DomainExceptions;
using UniversityTimetable.Shared.Interfaces.Domain.Validation;
using UniversityTimetable.Shared.Interfaces.DataAccess;
using UniversityTimetable.Shared.Interfaces.Domain;
using UniversityTimetable.Shared.Models;
using UniversityTimetable.Tests.Shared.DataFactories;
using UniversityTimetable.Tests.Shared.Extensions;

namespace UniversityTimetable.Tests.Unit.BackEnd.Domain.Services;

public class ClassServiceTests
{
    private readonly ClassService _sut;
    private readonly ITimetableDataAccessFacade _dataAccess = Substitute.For<ITimetableDataAccessFacade>();
    private readonly IBaseService<ClassDto> _baseService = Substitute.For<IBaseService<ClassDto>>();
    private readonly IUniversalValidator<ClassDto> _validator = Substitute.For<IUniversalValidator<ClassDto>>();
    private readonly Fixture _fixture = new();
    private readonly IMapper _mapper = MapperFactory.Mapper;

    public ClassServiceTests()
    {
        var logger = Substitute.For<ILogger<ClassService>>();
        _sut = new ClassService(logger, _dataAccess, _mapper, _baseService, _validator);
    }

    [Fact]
    public async Task Create_ReturnsFromBaseService()
    {
        var @class = CreateClass();
        _baseService.CreateAsync(@class).Returns(@class);

        var result = await _sut.CreateAsync(@class);

        result.Should().Be(@class);
        await _baseService.Received(1).CreateAsync(@class);
    }

    [Fact]
    public async Task Update_ReturnsFromBaseService()
    {
        var @class = CreateClass();
        _baseService.UpdateAsync(@class).Returns(@class);

        var result = await _sut.UpdateAsync(@class);

        result.Should().Be(@class);
        await _baseService.Received(1).UpdateAsync(@class);
    }

    [Fact]
    public async Task GetById_ReturnsFromBaseService()
    {
        var @class = CreateClass();
        _baseService.GetByIdAsync(10).Returns(@class);

        var result = await _sut.GetByIdAsync(10);

        result.Should().Be(@class);
        await _baseService.Received(1).GetByIdAsync(10);
    }

    [Fact]
    public async Task Delete_ReturnsFromBaseService()
    {
        await _sut.DeleteAsync(10);

        await _baseService.Received(1).DeleteAsync(10);
    }

    [Fact]
    public async Task Validate_ReturnsFromValidationFacade()
    {
        var errors = _fixture.CreateMany<KeyValuePair<string, string>>(10).ToList();
        var @class = CreateClass();
        _validator.ValidateAsync(@class).Returns(errors);

        var result = await _sut.ValidateAsync(@class);

        result.Should().BeEquivalentTo(errors);
        await _validator.Received(1).ValidateAsync(@class);
    }

    [Fact]
    private async Task GetTimetableForAuditory_ReturnsMappedFromRepository()
    {
        var data = new TimetableData
        {
            Classes = new ClassFactory().CreateMany(_fixture, 10),
            Auditory = new Auditory(),
            Group = new Group(),
            Teacher = new Teacher()
        };
        _dataAccess.GetTimetableForAuditoryAsync(10).Returns(data);
        var expected = new Timetable(_mapper.Map<List<ClassDto>>(data.Classes))
        {
            Auditory = new AuditoryDto()
        };

        var result = await _sut.GetTimetableForAuditoryAsync(10);

        result.Should().BeEquivalentTo(expected, opt => opt.ComparingByMembers<Timetable>());
    }

    [Fact]
    private async Task GetTimetableForGroup_ReturnsMappedFromRepository()
    {
        var data = new TimetableData
        {
            Classes = new ClassFactory().CreateMany(_fixture, 10),
            Auditory = new Auditory(),
            Group = new Group(),
            Teacher = new Teacher()
        };
        _dataAccess.GetTimetableForGroupAsync(10).Returns(data);
        var expected = new Timetable(_mapper.Map<List<ClassDto>>(data.Classes))
        {
            Group = new GroupDto()
        };

        var result = await _sut.GetTimetableForGroupAsync(10);

        result.Should().BeEquivalentTo(expected, opt => opt.ComparingByMembers<Timetable>());
    }

    [Fact]
    private async Task GetTimetableForTeacher_ReturnsMappedFromRepository()
    {
        var data = new TimetableData
        {
            Classes = new ClassFactory().CreateMany(_fixture, 10),
            Auditory = new Auditory(),
            Group = new Group(),
            Teacher = new TeacherFactory().CreateModel(_fixture)
        };
        _dataAccess.GetTimetableForTeacherAsync(10).Returns(data);
        var expected = new Timetable(_mapper.Map<List<ClassDto>>(data.Classes))
        {
            Teacher = _mapper.Map<TeacherDto>(data.Teacher)
        };

        var result = await _sut.GetTimetableForTeacherAsync(10);

        result.Should().BeEquivalentTo(expected, opt => opt.ComparingByMembers<Timetable>());
    }

    [Fact]
    public async Task GetTimetableForAuditory_ShouldThrowException_WhenIdIsNull()
    {
        await new Func<Task>(() => _sut.GetTimetableForAuditoryAsync(null)).Should()
            .ThrowAsync<NullIdException>()
            .WithMessage(new NullIdException().Message);
    }
    
    [Fact]
    public async Task GetTimetableForGroup_ShouldThrowException_WhenIdIsNull()
    {
        await new Func<Task>(() => _sut.GetTimetableForGroupAsync(null)).Should()
            .ThrowAsync<NullIdException>()
            .WithMessage(new NullIdException().Message);
    }
    
    [Fact]
    public async Task GetTimetableForTeacher_ShouldThrowException_WhenIdIsNull()
    {
        await new Func<Task>(() => _sut.GetTimetableForTeacherAsync(null)).Should()
            .ThrowAsync<NullIdException>()
            .WithMessage(new NullIdException().Message);
    }

    private ClassDto CreateClass()
    {
        var rand = new Random();
        return _fixture.Build<ClassDto>()
            .Without(c => c.Auditory)
            .Without(c => c.Group)
            .Without(c => c.Subject)
            .Without(c => c.Teacher)
            .With(c => c.Number, rand.Next(0, 5))
            .With(c => c.DayOfWeek, rand.Next(0, 6))
            .Create();
    }
}