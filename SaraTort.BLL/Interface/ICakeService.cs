using SaraTort.BLL.DTOs.Cake;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.BLL.Interfaces;

public interface ICakeService
    : ICrudService<Cake, CakeForCreateDto, CakeForUpdateDto, CakeForResultDto>
{
}