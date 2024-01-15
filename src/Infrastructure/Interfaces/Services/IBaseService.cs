namespace Infrastructure.Interfaces.Services;

public interface IBaseService<TDto, in TCreateDto, in TUpdateDto>
{
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<TDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ICollection<TDto>> GetManyAsync(int skip, int take, CancellationToken cancellationToken = default);
    Task<TDto> CreateAsync(TCreateDto createDto, CancellationToken cancellationToken = default);
    Task<TDto> UpdateAsync(int id, TUpdateDto updateDto, CancellationToken cancellationToken = default);
}
