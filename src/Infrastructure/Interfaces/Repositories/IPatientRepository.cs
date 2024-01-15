using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<IEnumerable<Doctor>> GetManyAsync(string name, int skip, int take, 
        CancellationToken cancellationToken = default);
}
