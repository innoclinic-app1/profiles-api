using Domain.Entities;
using Infrastructure.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class PatientRepository : BaseRepository<Patient>, IPatientRepository
{
    public PatientRepository(DataContext context) : base(context)
    {
    }

    public IQueryable<Patient> GetByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Context.Patients.AsQueryable();
        }

        var searchName = name.ToLower();
        
        var result = Context.Patients
            .Where(d =>
                d.FirstName.ToLower().Contains(searchName) || d.LastName.ToLower().Contains(searchName) ||
                (d.MiddleName != null && d.MiddleName.ToLower().Contains(searchName))
            );
        
        return result;
    }
}
