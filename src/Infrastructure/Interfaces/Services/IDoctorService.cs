using Domain.Dtos.Doctors;
using Domain.Enums;

namespace Infrastructure.Interfaces.Services;

public interface IDoctorService : IBaseService<DoctorDto, DoctorCreateDto, DoctorUpdateDto>
{
    Task<ICollection<DoctorDto>> GetManyAsync(string name, int officeId, int specializationId, 
        int skip, int take, CancellationToken cancellation = default);
    
    Task ChangeStatusAsync(int id, EmployeeStatus status, CancellationToken cancellation);
}
