using Domain.Entities;
using Status = Domain.Enums.EmployeeStatus;

namespace Infrastructure.Interfaces.Repositories;

public interface IDoctorRepository : IBaseRepository<Doctor>
{
    Task ChangeStatusAsync(int id, Status status);

    IQueryable<Doctor> GetByName(string name);
    IQueryable<Doctor> GetByOffice(int officeId);
    IQueryable<Doctor> GetBySpecialization(int specializationId);
}
