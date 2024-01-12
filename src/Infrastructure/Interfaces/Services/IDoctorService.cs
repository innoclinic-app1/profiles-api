using Domain.Dtos.Doctors;

namespace Infrastructure.Interfaces.Services;

public interface IDoctorService : IBaseService<DoctorDto, DoctorCreateDto, DoctorUpdateDto>
{
    Task<ICollection<DoctorDto>> GetFilteredAsync(string name, int officeId, int specializationId, int skip, int take);
}
