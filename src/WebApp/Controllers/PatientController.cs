using System.ComponentModel.DataAnnotations;
using Domain.Dtos.Patients;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("patients")]
[Produces("application/json")]
public class PatientController : ControllerBase
{
    private IPatientService Service { get; }
    
    public PatientController(IPatientService service) => Service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetMany(CancellationToken cancellationToken, 
        [Required] int offset = 0, [Required] int limit = 50,
        string name = "")
    {
        var patients = await Service.GetManyAsync(name, offset, limit, cancellationToken);

        return Ok(patients);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var patient = await Service.GetByIdAsync(id, cancellationToken);

        return Ok(patient);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken)
    {
        await Service.DeleteAsync(id, cancellationToken);

        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(PatientCreateDto createDto, CancellationToken cancellationToken)
    {
        var patient = await Service.CreateAsync(createDto, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, PatientUpdateDto updateDto, CancellationToken cancellationToken)
    {
        var patient = await Service.UpdateAsync(id, updateDto, cancellationToken);

        return Ok(patient);
    }
}
