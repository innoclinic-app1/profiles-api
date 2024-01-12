using Domain.Entities;
using Status = Domain.Enums.EmployeeStatus;

namespace Infrastructure.Interfaces.Repositories;

public interface IDoctorRepository : IBaseRepository<Doctor>
{
    Task ChangeStatusAsync(int id, Status status);

    Task<IQueryable<Doctor>> GetByOfficeAsync(int officeId, CancellationToken cancellationToken = default);
    
    Task<IQueryable<Doctor>> GetBySpecializationAsync(int specializationId,
        CancellationToken cancellationToken = default);
}
