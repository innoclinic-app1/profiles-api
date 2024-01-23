using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Status = Domain.Enums.EmployeeStatus;

namespace Infrastructure.Repositories;

public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
{
    public DoctorRepository(DataContext context) : base(context)
    {
    }

    public async Task ChangeStatusAsync(int id, Status status, CancellationToken cancellation = default)
    {
        try
        {
            await Context.Doctors.Where(d => d.Id == id)
                .ExecuteUpdateAsync(d =>
                    d.SetProperty(x => x.Status, status), cancellation);
        }
        catch (ArgumentNullException)
        {
            throw new NotFoundException(nameof(Doctor), id);
        }
    }

    public async Task<IEnumerable<Doctor>> GetManyAsync(string name, int officeId, int specializationId,
        int skip, int take, CancellationToken cancellation = default)
    {
        var query = Context.Doctors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = GetByName(query, name);
        }

        if (officeId != 0)
        {
            query = GetByOffice(query, officeId);
        }

        if (specializationId != 0)
        {
            query = GetBySpecialization(query, specializationId);
        }

        return await GetManyAsync(query, skip, take, cancellation);
    }

    private static IQueryable<Doctor> GetByName(IQueryable<Doctor> query, string name)
    {
        var searchName = name.ToLower();

        var result = query.Where(d =>
            d.FirstName.ToLower().Contains(searchName) ||
            d.LastName.ToLower().Contains(searchName) ||
            (d.MiddleName != null && d.MiddleName.ToLower().Contains(searchName))
        );

        return result;
    }

    private static IQueryable<Doctor> GetByOffice(IQueryable<Doctor> query, int officeId)
    {
        var result = query.Where(d => d.OfficeId == officeId);

        return result;
    }

    private static IQueryable<Doctor> GetBySpecialization(IQueryable<Doctor> query, int specializationId)
    {
        return query.Where(d => d.SpecializationId == specializationId);
    }

    public override async Task UpdateAsync(int id, Doctor entity, CancellationToken cancellation = default)
    {
        try
        {
            await Context.Doctors
                .Where(d => d.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.FirstName, entity.FirstName)
                    .SetProperty(e => e.MiddleName, entity.MiddleName)
                    .SetProperty(e => e.LastName, entity.LastName)
                    .SetProperty(e => e.SpecializationId, entity.SpecializationId)
                    .SetProperty(e => e.OfficeId, entity.OfficeId)
                    .SetProperty(e => e.BirthDate, entity.BirthDate)
                    .SetProperty(e => e.CareerStartYear, entity.CareerStartYear)
                    .SetProperty(e => e.Status, entity.Status), cancellation);
        }
        catch (ArgumentNullException)
        {
            throw new NotFoundException(nameof(Doctor), id);
        }
    }
}
