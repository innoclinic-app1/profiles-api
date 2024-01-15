using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IReceptionistRepository : IBaseRepository<Receptionist>
{ 
    Task<IEnumerable<Doctor>> GetManyAsync(string name, int skip, int take, 
        CancellationToken cancellationToken = default);
}
