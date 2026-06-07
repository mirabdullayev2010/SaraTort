using SaraTort.BLL.DTOs.Category;
using SaraTort.BLL.Interfaces;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.BLL.Interface;

public interface ICategoryService : ICrudService<Category, CategoryForCreateDto, CategoryForUpdateDto, CategoryForResultDto>
{

}
