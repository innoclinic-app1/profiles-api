using Domain.Dtos.Receptionists;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Interfaces.Services;
using Mapster;

namespace Infrastructure.Services;

public class ReceptionistService : BaseService<Receptionist, ReceptionistDto, ReceptionistCreateDto, ReceptionistUpdateDto>, IReceptionistService
{
    private IReceptionistRepository Repository { get; }
    public ReceptionistService(IReceptionistRepository repository) : base(repository)
    {
        Repository = repository;
    }

    public async Task<ICollection<ReceptionistDto>> GetManyAsync(string name, int skip, int take, CancellationToken cancellationToken = default)
    {
        var receptionists = await Repository.GetManyAsync(name, skip, take, cancellationToken);
        
        return receptionists.Adapt<ICollection<ReceptionistDto>>();
    }
}
