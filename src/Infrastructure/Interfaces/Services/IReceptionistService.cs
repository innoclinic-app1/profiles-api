using Domain.Dtos.Receptionists;

namespace Infrastructure.Interfaces.Services;

public interface IReceptionistService : IBaseService<ReceptionistDto, ReceptionistCreateDto, ReceptionistUpdateDto>
{
    Task<ICollection<ReceptionistDto>> GetFilteredAsync(string name, int skip, int take,
        CancellationToken cancellationToken = default);
}
