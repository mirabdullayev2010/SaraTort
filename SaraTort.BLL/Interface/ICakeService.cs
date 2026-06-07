using SaraTort.BLL.DTOs.Cake;
using SaraTort.BLL.Interfaces;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.BLL.Interface;

public interface ICakeService : ICrudService<Cake, CakeForCreateDto, CakeForUpdateDto, CakeForResultDto>
{

}
