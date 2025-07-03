using Educon.Models;
using Educon.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IEnumerable<School>> Get()
    {
        return await _repository.GetAllAsync();
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
