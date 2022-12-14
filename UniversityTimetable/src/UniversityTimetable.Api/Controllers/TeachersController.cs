using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityTimetable.Domain.Auth;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Enums;
using UniversityTimetable.Shared.Interfaces.Domain;
using UniversityTimetable.Shared.QueryParameters;

namespace UniversityTimetable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly IParametersService<TeacherDto, TeacherParameters> _service;

        public TeachersController(IParametersService<TeacherDto, TeacherParameters> service)
        {
            _service = service;
        }

        // GET: Teachers
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] TeacherParameters parameters)
        {
            return Ok(await _service.GetByParametersAsync(parameters));
        }

        // GET: Teachers/Details/5
        [HttpGet("{id:int?}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpPost]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Post(TeacherDto teacher)
        {
            await _service.CreateAsync(teacher);
            return Ok(teacher);
        }

        [HttpPut]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Put(TeacherDto teacher)
        {
            await _service.UpdateAsync(teacher);
            return Ok(teacher);
        }
        
        [HttpDelete("{id:int?}")]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteAsync(id);
            return Ok(id);
        }
    }
}
