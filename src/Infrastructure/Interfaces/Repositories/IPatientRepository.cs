using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IPatientRepository : IBaseRepository<Patient>
{
    Task<IEnumerable<Patient>> GetManyAsync(string name, int skip, int take, 
        CancellationToken cancellation = default);
}
