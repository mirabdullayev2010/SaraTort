using AutoMapper;
using FluentValidation;
using SaraTort.BLL.DTOs.Cake;
using SaraTort.BLL.Interfaces;
using SaraTort.DAL.Interfaces;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.BLL.Services;

public class CakeService : ICakeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CakeForCreateDto> _createValidator;
    private readonly IValidator<CakeForUpdateDto> _updateValidator;

    public CakeService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CakeForCreateDto> createValidator,
        IValidator<CakeForUpdateDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<long> CreateAsync(CakeForCreateDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cake = _mapper.Map<Cake>(dto);

        await _unitOfWork.Repository<Cake>().AddAsync(cake);

        await _unitOfWork.SaveAsync();

        return cake.Id;
    }

    public async Task<bool> UpdateAsync(long id, CakeForUpdateDto dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cake = await _unitOfWork.Repository<Cake>()
            .GetAsync(x => x.Id == id);

        if (cake is null)
            return false;

        _mapper.Map(dto, cake);

        _unitOfWork.Repository<Cake>().Update(cake);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var cake = await _unitOfWork.Repository<Cake>()
            .GetAsync(x => x.Id == id);

        if (cake is null)
            return false;

        _unitOfWork.Repository<Cake>().Delete(cake);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<CakeForResultDto> GetByIdAsync(long id)
    {
        var cake = await _unitOfWork.Repository<Cake>()
            .GetAsync(
                x => x.Id == id,
                includes: new[]
                {
                    nameof(Cake.Category),
                    nameof(Cake.Reviews)
                });

        if (cake is null)
            throw new Exception("Cake topilmadi.");

        return _mapper.Map<CakeForResultDto>(cake);
    }

    public async Task<IEnumerable<CakeForResultDto>> GetAllAsync()
    {
        var cakes = await _unitOfWork.Repository<Cake>()
            .GetAllAsync(
                includes: new[]
                {
                    nameof(Cake.Category),
                    nameof(Cake.Reviews)
                });

        return _mapper.Map<IEnumerable<CakeForResultDto>>(cakes);
    }
}