using Microsoft.AspNetCore.Mvc;
using UniversityTimetable.Api.Controllers;
using UniversityTimetable.Shared.DataContainers;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Interfaces.Domain;
using UniversityTimetable.Shared.QueryParameters;

namespace UniversityTimetable.Tests.Unit.BackEnd.Api.Controllers;

public class TeachersControllerTests
{
    private readonly IParametersService<TeacherDto, TeacherParameters> _service = Substitute.For<IParametersService<TeacherDto, TeacherParameters>>();
    private readonly TeachersController _controller;
    private readonly Fixture _fixture;
    public TeachersControllerTests()
    {
        _controller = new TeachersController(_service);
        _fixture = new Fixture();
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task GetById_ReturnsFromService_ServiceCalled()
    {
        var data = _fixture.Build<TeacherDto>().With(t => t.Id, 10).Create();

        _service.GetByIdAsync(10).Returns(data);
        var actionResult = await _controller.Get(10);

        actionResult.Should().BeOfType<OkObjectResult>();
        actionResult.As<OkObjectResult>().Value.Should().Be(data);
        await _service.Received().GetByIdAsync(10);
    }

    [Fact]
    public async Task Delete_ReturnsIdFromService_ServiceCalled()
    {
        var actionResult = await _controller.Delete(10);

        actionResult.Should().BeOfType<OkObjectResult>();
        actionResult.As<OkObjectResult>().Value.Should().Be(10);
        await _service.Received().DeleteAsync(10);
    }

    [Fact]
    public async Task Create_ReturnsFromService_ServiceCalled()
    {
        var data = _fixture.Create<TeacherDto>();
        _service.CreateAsync(data).Returns(data);

        var actionResult = await _controller.Post(data);

        actionResult.Should().BeOfType<OkObjectResult>();
        actionResult.As<OkObjectResult>().Value.Should().Be(data);
        await _service.Received().CreateAsync(data);
    }

    [Fact]
    public async Task Update_ReturnsFromService_ServiceCalled()
    {
        var data = _fixture.Create<TeacherDto>();
        _service.UpdateAsync(data).Returns(data);

        var actionResult = await _controller.Put(data);

        actionResult.Should().BeOfType<OkObjectResult>();
        actionResult.As<OkObjectResult>().Value.Should().Be(data);
        await _service.Received().UpdateAsync(data);
    }

    [Fact]
    public async Task GetByParameters_ReturnsFromService_ServiceCalled()
    {
        var data = _fixture.Build<ListWithPaginationData<TeacherDto>>()
            .With(l => l.Data, Enumerable.Range(0, 5)
                .Select(_ => _fixture.Create<TeacherDto>()).ToList())
            .Create();

        _service.GetByParametersAsync(Arg.Any<TeacherParameters>()).Returns(data);
        var actionResult = await _controller.Get(new TeacherParameters());

        actionResult.Should().BeOfType<OkObjectResult>();
        actionResult.As<OkObjectResult>().Value.Should().Be(data);
        await _service.Received().GetByParametersAsync(Arg.Any<TeacherParameters>());
    }
}