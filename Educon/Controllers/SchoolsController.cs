using Educon.Models;
using Educon.Repositories;
using Educon.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Educon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController : ControllerBase
{
    private readonly ISchoolService _service;

    public SchoolsController(ISchoolService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<PagedResult<School>> Get(
        string? search,
        string? sortBy,
        bool ascending = true,
        SchoolType? type = null,
        SchoolStatus? status = null,
        SchoolLevel? level = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        return await _service.GetSchoolsAsync(
            page,
            pageSize,
            search,
            sortBy,
            ascending,
            type,
            status,
            level,
            cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<School>> Get(Guid id, CancellationToken cancellationToken)
    {
        var school = await _service.GetByIdAsync(id, cancellationToken);
        if (school == null)
        {
            return NotFound();
        }
        return Ok(school);
    }

    [HttpPost]
    public async Task<ActionResult<School>> Post(School school, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(school, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = school.Id }, school);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, School school, CancellationToken cancellationToken)
    {
        if (id != school.Id)
        {
            return BadRequest();
        }
        await _service.UpdateAsync(school, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _service.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
