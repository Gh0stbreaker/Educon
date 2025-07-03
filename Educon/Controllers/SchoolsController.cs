using Educon.Models;
using Educon.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Educon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController : ControllerBase
{
    private readonly ISchoolRepository _repository;

    public SchoolsController(ISchoolRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IEnumerable<School>> Get(
        string? search,
        string? sortBy,
        bool ascending = true,
        SchoolType? type = null,
        SchoolStatus? status = null,
        SchoolLevel? level = null)
    {
        Expression<Func<School, bool>>? filter = null;
        if (type.HasValue || status.HasValue || level.HasValue)
        {
            filter = s =>
                (!type.HasValue || s.Type == type.Value) &&
                (!status.HasValue || s.Status == status.Value) &&
                (!level.HasValue || s.Level == level.Value);
        }

        Expression<Func<School, object>>? orderBy = null;
        if (!string.IsNullOrEmpty(sortBy))
        {
            orderBy = sortBy.ToLower() switch
            {
                "name" => s => s.Name,
                "type" => s => s.Type,
                "level" => s => s.Level,
                "status" => s => s.Status,
                "address" => s => s.Address,
                "email" => s => s.Email!,
                "phone" => s => s.Phone!,
                "ico" => s => s.Ico!,
                "director" => s => s.Director!,
                _ => null
            };
        }

        return await _repository.GetAsync(filter, orderBy, ascending, search);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<School>> Get(Guid id)
    {
        var school = await _repository.GetByIdAsync(id);
        if (school == null)
        {
            return NotFound();
        }
        return Ok(school);
    }

    [HttpPost]
    public async Task<ActionResult<School>> Post(School school)
    {
        await _repository.AddAsync(school);
        return CreatedAtAction(nameof(Get), new { id = school.Id }, school);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, School school)
    {
        if (id != school.Id)
        {
            return BadRequest();
        }
        await _repository.UpdateAsync(school);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}
