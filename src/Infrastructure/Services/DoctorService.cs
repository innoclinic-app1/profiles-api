using Domain.Dtos.Doctors;
using Domain.Entities;
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

    public async Task<ICollection<DoctorDto>> GetManyAsync(string name, int officeId, int specializationId, int skip, int take,
        CancellationToken cancellationToken = default)
    {
        var doctors = await Repository.GetManyAsync(name, officeId, specializationId, skip, take, cancellationToken);

        return doctors.Adapt<ICollection<DoctorDto>>();
    }
}
