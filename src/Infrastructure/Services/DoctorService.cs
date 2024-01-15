using Domain.Dtos.Doctors;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;

namespace Infrastructure.Services;

public class DoctorService : BaseService<Doctor, DoctorDto, DoctorCreateDto, DoctorUpdateDto>, IDoctorService
{
    public DoctorService(IBaseRepository<Doctor> repository) : base(repository)
    {
    }

    public Task<ICollection<DoctorDto>> GetFilteredAsync(string name, int officeId, int specializationId, int skip, int take,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
