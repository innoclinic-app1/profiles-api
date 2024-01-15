using Domain.Dtos.Patients;

namespace Infrastructure.Interfaces.Services;

public interface IPatientService : IBaseService<PatientDto, PatientCreateDto, PatientUpdateDto>
{
    Task<ICollection<PatientDto>> GetFilteredAsync(string name, int skip, int take, 
        CancellationToken cancellationToken = default);
}
