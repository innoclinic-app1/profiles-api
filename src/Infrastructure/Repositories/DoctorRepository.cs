using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Status = Domain.Enums.EmployeeStatus;

namespace Infrastructure.Repositories;

public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(DataContext context) : base(context)
    {
        
    }

    public async Task ChangeStatusAsync(int id, Status status)
    {
        var doctor = await GetByIdAsync(id);

        doctor.Status = status;
        
        await Context.SaveChangesAsync();
    }

    public IQueryable<Doctor> GetByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Context.Doctors.AsQueryable();
        }

        var searchName = name.ToLower();
        
        var result = Context.Doctors
            .Where(d =>
                d.FirstName.ToLower().Contains(searchName) || d.LastName.ToLower().Contains(searchName) ||
                (d.MiddleName != null && d.MiddleName.ToLower().Contains(searchName))
            );
        
        return result;
    }

    public IQueryable<Doctor> GetByOffice(int officeId)
    {
        var result = Context.Doctors.Where(d => d.OfficeId == officeId);

        return result;
    }

    public IQueryable<Doctor> GetBySpecialization(int specializationId)
    {
        return Context.Doctors.Where(d => d.SpecializationId == specializationId);
    }
}



