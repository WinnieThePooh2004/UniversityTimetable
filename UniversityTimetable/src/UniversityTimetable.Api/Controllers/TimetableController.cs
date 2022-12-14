using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityTimetable.Domain.Auth;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Enums;
using UniversityTimetable.Shared.Interfaces.Domain;

namespace UniversityTimetable.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimetableController : ControllerBase
    {
        private readonly IClassService _service;

        public TimetableController(IClassService service)
        {
            _service = service;
        }

        [HttpGet("Auditory/{auditoryId:int?}")]
        [AllowAnonymous]
        public async Task<IActionResult> AuditoryTimetable(int? auditoryId)
        {
            var table = await _service.GetTimetableForAuditoryAsync(auditoryId);
            return Ok(table);
        }

        [HttpGet("Group/{groupId:int?}")]
        [AllowAnonymous]
        public async Task<IActionResult> GroupTimetable(int? groupId)
        {
            var table = await _service.GetTimetableForGroupAsync(groupId);
            return Ok(table);
        }

        [HttpGet("Teacher/{teacherId:int?}")]
        [AllowAnonymous]
        public async Task<IActionResult> TeacherTimetable(int? teacherId)
        {
            var table = await _service.GetTimetableForTeacherAsync(teacherId);
            return Ok(table);
        }

        // GET: Classes/Details/5
        [HttpGet("{id:int?}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int? id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }


        // GET: Classes/Create
        [HttpPost]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Post(ClassDto @class)
        {
            return Ok(await _service.CreateAsync(@class));
        }

        [HttpPut]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Put(ClassDto @class)
        {
            return Ok(await _service.UpdateAsync(@class));
        }

        [HttpDelete("{id:int?}")]
        [Authorized(UserRole.Admin)]
        public async Task<IActionResult> Delete(int? id)
        {
            await _service.DeleteAsync(id);
            return Ok(id);
        }

        [HttpPut("Validate")]
        public async Task<IActionResult> Validate(ClassDto model)
        {
            return Ok(await _service.ValidateAsync(model));
        }
    }
}
