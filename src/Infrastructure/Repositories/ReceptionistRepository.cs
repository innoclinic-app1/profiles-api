using Domain.Entities;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class ReceptionistRepository : BaseRepository<Receptionist>, IReceptionistRepository
{
    public ReceptionistRepository(DataContext context) : base(context)
    {
    }

    public IQueryable<Receptionist> GetByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Context.Receptionists.AsQueryable();
        }

        var searchName = name.ToLower();
        
        var result = Context.Receptionists
            .Where(d =>
                d.FirstName.ToLower().Contains(searchName) || d.LastName.ToLower().Contains(searchName) ||
                (d.MiddleName != null && d.MiddleName.ToLower().Contains(searchName))
            );
        
        return result;
    }
}
