using SaraTort.BLL.DTOs.CakeReview;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Shared.DTOs.CakeRaview;

namespace SaraTort.BLL.Interfaces;

public interface ICakeReviewService
    : ICroudService<CakeReview, CakeReviewForCreateDto, CakeReviewForUpdateDto, CakeReviewForResultDto>
{
}