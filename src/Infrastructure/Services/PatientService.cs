using Domain.Dtos.Patients;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Mapster;

namespace Infrastructure.Services;

public class PatientService : BaseService<Patient, PatientDto, PatientCreateDto, PatientUpdateDto>, IPatientService
{
    private IPatientRepository Repository { get; }
    
    public PatientService(IPatientRepository repository) : base(repository)
    {
        Repository = repository;
    }

    public async Task<ICollection<PatientDto>> GetManyAsync(string name, int skip, int take,
        CancellationToken cancellation = default)
    {
        var patients = await Repository.GetManyAsync(name, skip, take, cancellation);
        
        return patients.Adapt<ICollection<PatientDto>>();
    }
}
