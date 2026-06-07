namespace SaraTort.BLL.Interfaces;
public interface ICrudService<TModel, TCreateDto, TUpdateDto, TResultDto>
    where TModel : class
    where TCreateDto : class
    where TUpdateDto : class
    where TResultDto : class
{
    Task<TResultDto> CreateAsync(TCreateDto dto);
    Task<TResultDto> UpdateAsync(TUpdateDto dto);
    Task<bool> DeleteAsync(int id);
    Task<TResultDto> GetByIdAsync(int id);
    Task<IEnumerable<TResultDto>> GetAllAsync();
}