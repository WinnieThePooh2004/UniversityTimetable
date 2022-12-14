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
    public class DepartmentsController : ControllerBase
    {
        private readonly IParametersService<DepartmentDto, DepartmentParameters> _service;
        public DepartmentsController(IParametersService<DepartmentDto, DepartmentParameters> service)
        {
            _service = service;
        }

        // GET: Departments
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] DepartmentParameters parameters)
        {
            return Ok(await _service.GetByParametersAsync(parameters));
        }

        // GET: Departments/Details/5
        [HttpGet("{id:int?}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Post(DepartmentDto department)
        {
            await _service.CreateAsync(department);
            return Ok(department);
        }

        [HttpPut]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Put(DepartmentDto department)
        {
            await _service.UpdateAsync(department);
            return Ok(department);
        }

        // GET: Departments/Delete/5
        [HttpDelete("{id:int?}")]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteAsync(id);
            return Ok(id);
        }
    }
}
