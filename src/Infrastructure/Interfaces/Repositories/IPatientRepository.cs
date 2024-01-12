using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IPatientRepository : IBaseRepository<Patient>
{
    IQueryable<Patient> GetByName(string name);
}
