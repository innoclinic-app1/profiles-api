using Domain.Dtos.Receptionists;
using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ReceptionistController : ControllerBase
{
    private IReceptionistService Service { get; }
    
    public ReceptionistController(IReceptionistService service) => Service = service;
    
    [HttpGet]
    public async Task<IActionResult> GetMany(string name, int skip, int take,
        CancellationToken cancellationToken = default)
    {
        var patients = await Service.GetManyAsync(name, skip, take, cancellationToken);
        
        return Ok(patients);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
    {
        var patient = await Service.GetByIdAsync(id, cancellationToken);
        
        return Ok(patient);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id, CancellationToken cancellationToken = default)
    {
        await Service.DeleteAsync(id, cancellationToken);
        
        return NoContent();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ReceptionistCreateDto createDto, CancellationToken cancellationToken = default)
    {
        var patient = await Service.CreateAsync(createDto, cancellationToken);
        
        return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ReceptionistUpdateDto updateDto, CancellationToken cancellationToken = default)
    {
        var patient = await Service.UpdateAsync(id, updateDto, cancellationToken);
        
        return Ok(patient);
    }
}
