using SaraTort.BLL.DTOs.CakeReview;
using SaraTort.BLL.Interfaces;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Shared.DTOs.CakeRaview;

namespace SaraTort.BLL.Interface;

public interface ICakeReviewService : ICrudService<CakeReview, CakeReviewForCreateDto, CakeReviewForUpdateDto, CakeReviewForResultDto>
{

}
