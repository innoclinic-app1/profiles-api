using Domain.Dtos.Doctors;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Mapster;

namespace Infrastructure.Services;

public class DoctorService : BaseService<Doctor, DoctorDto, DoctorCreateDto, DoctorUpdateDto>, IDoctorService
{
    private IDoctorRepository Repository { get; }
    
    public DoctorService(IDoctorRepository repository) : base(repository)
    {
        Repository = repository;
    }
    
    public async Task<ICollection<DoctorDto>> GetManyAsync(string name, int officeId, int specializationId, 
        int skip, int take, CancellationToken cancellation = default)
    {
        var doctors = await Repository.GetManyAsync(name, officeId,
            specializationId, skip, take, cancellation);

        return doctors.Adapt<ICollection<DoctorDto>>();
    }

    public async Task ChangeStatusAsync(int id, EmployeeStatus status, CancellationToken cancellation)
    {
        await Repository.ChangeStatusAsync(id, status, cancellation);
    }
}
