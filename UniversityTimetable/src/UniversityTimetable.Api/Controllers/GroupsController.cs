﻿using Microsoft.AspNetCore.Mvc;
using UniversityTimetable.Shared.DataTransferObjects;
using UniversityTimetable.Shared.Interfaces.Services;
using UniversityTimetable.Shared.QueryParameters;

namespace UniversityTimetable.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IService<GroupDTO, GroupParameters> _service;

        public GroupsController(IService<GroupDTO, GroupParameters> service)
        {
            _service = service;
        }

        // GET: Groups
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] GroupParameters parameters)
        {
            return Ok(await _service.GetByParametersAsync(parameters));
        }

        // GET: Groups/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroupDTO group)
        {
            if (!ModelState.IsValid || group.DepartmentId == 0)
            {
                return BadRequest(group);
            }
            await _service.CreateAsync(group);
            return Ok(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GroupDTO group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(group);
            }
            await _service.CreateAsync(group);
            return Ok(group);
        }

        // POST: Groups/Delete/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return Ok(id);
        }
    }
}
