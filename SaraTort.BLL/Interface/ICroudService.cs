namespace SaraTort.BLL.Interfaces;

public interface ICroudService<TModel, TCreateDto, TUpdateDto, TResultDto>
    where TModel : class
    where TCreateDto : class
    where TUpdateDto : class
    where TResultDto : class
{
    Task<long> CreateAsync(TCreateDto dto);

    Task<bool> UpdateAsync(long id, TUpdateDto dto);

    Task<bool> DeleteAsync(long id);

    Task<TResultDto> GetByIdAsync(long id);
}