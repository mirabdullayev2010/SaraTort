using SaraTort.BLL.DTOs.CakeOption;
using SaraTort.BLL.Interfaces;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.BLL.Interface;

public interface ICakeOptionService : ICrudService<CakeOption, CakeOptionForCreateDto, CakeOptionForUpdateDto, CakeOptionForResultDto>
{

}
