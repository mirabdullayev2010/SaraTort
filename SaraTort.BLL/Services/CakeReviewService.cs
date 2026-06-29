using AutoMapper;
using FluentValidation;
using SaraTort.BLL.DTOs.CakeReview;
using SaraTort.BLL.Interfaces;
using SaraTort.DAL.Interfaces;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Shared.DTOs.CakeRaview;

namespace SaraTort.BLL.Services;

public class CakeReviewService : ICakeReviewService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CakeReviewForCreateDto> _createValidator;
    private readonly IValidator<CakeReviewForUpdateDto> _updateValidator;

    public CakeReviewService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CakeReviewForCreateDto> createValidator,
        IValidator<CakeReviewForUpdateDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<long> CreateAsync(CakeReviewForCreateDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var review = _mapper.Map<CakeReview>(dto);

        await _unitOfWork.Repository<CakeReview>().AddAsync(review);

        await _unitOfWork.SaveAsync();

        return review.Id;
    }

    public async Task<bool> UpdateAsync(long id, CakeReviewForUpdateDto dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var review = await _unitOfWork.Repository<CakeReview>()
            .GetAsync(x => x.Id == id);

        if (review is null)
            return false;

        _mapper.Map(dto, review);

        _unitOfWork.Repository<CakeReview>().Update(review);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var review = await _unitOfWork.Repository<CakeReview>()
            .GetAsync(x => x.Id == id);

        if (review is null)
            return false;

        _unitOfWork.Repository<CakeReview>().Delete(review);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<CakeReviewForResultDto> GetByIdAsync(long id)
    {
        var review = await _unitOfWork.Repository<CakeReview>()
            .GetAsync(
                x => x.Id == id,
                includes: new[]
                {
                    nameof(CakeReview.Cake)
                });

        if (review is null)
            throw new Exception("Cake review topilmadi.");

        return _mapper.Map<CakeReviewForResultDto>(review);
    }

    public async Task<IEnumerable<CakeReviewForResultDto>> GetAllAsync()
    {
        var reviews = await _unitOfWork.Repository<CakeReview>()
            .GetAllAsync(
                includes: new[]
                {
                    nameof(CakeReview.Cake)
                });

        return _mapper.Map<IEnumerable<CakeReviewForResultDto>>(reviews);
    }
}