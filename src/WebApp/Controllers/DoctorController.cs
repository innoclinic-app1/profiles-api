using System.ComponentModel.DataAnnotations;
using Domain.Dtos.Doctors;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("doctors")]
[Produces("application/json")]
public class DoctorController : ControllerBase
{
    private IDoctorService Service { get; }

    public DoctorController(IDoctorService service) => Service = service;

    [HttpGet]
    public async Task<IActionResult> GetMany(CancellationToken cancellationToken, 
        [Required] int offset = 0, [Required] int limit = 50,
        string name = "", int officeId = 0, int specializationId = 0)
    {
        var doctors = await Service.GetManyAsync(name, officeId, 
            specializationId, offset, limit, cancellationToken);

        return Ok(doctors);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var doctor = await Service.GetByIdAsync(id, cancellationToken);

        return Ok(doctor);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
    {
        await Service.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(DoctorCreateDto createDto, CancellationToken cancellationToken)
    {
        var doctor = await Service.CreateAsync(createDto, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, doctor);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, DoctorUpdateDto updateDto, CancellationToken cancellationToken)
    {
        var doctor = await Service.UpdateAsync(id, updateDto, cancellationToken);

        return Ok(doctor);
    }
}
