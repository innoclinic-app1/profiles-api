namespace Infrastructure.Interfaces.Services;

public interface IBaseService<TDto, in TCreateDto, in TUpdateDto>
{
    Task DeleteAsync(int id);
    Task<TDto> GetByIdAsync(int id);
    Task<ICollection<TDto>> GetManyAsync(int skip, int take);
    Task<TDto> CreateAsync(TCreateDto createDto);
    Task<TDto> UpdateAsync(int id, TUpdateDto updateDto);
}
