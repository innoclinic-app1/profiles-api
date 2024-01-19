using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IReceptionistRepository : IBaseRepository<Receptionist>
{ 
    Task<IEnumerable<Receptionist>> GetManyAsync(string name, int skip, int take, 
        CancellationToken cancellation = default);
}
