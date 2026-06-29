using SaraTort.BLL.DTOs.Category;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.BLL.Interfaces;

public interface ICategoryService
    : ICrudService<Category, CategoryForCreateDto, CategoryForUpdateDto, CategoryForResultDto>
{
}