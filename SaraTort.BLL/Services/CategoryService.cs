using AutoMapper;
using FluentValidation;
using SaraTort.BLL.DTOs.Category;
using SaraTort.BLL.Interfaces;
using SaraTort.DAL.Interfaces;
using SaraTort.Domain.Entities.Catalog;

namespace SaraTort.BLL.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CategoryForCreateDto> _createValidator;
    private readonly IValidator<CategoryForUpdateDto> _updateValidator;

    public CategoryService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CategoryForCreateDto> createValidator,
        IValidator<CategoryForUpdateDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }
    public async Task<long> CreateAsync(CategoryForCreateDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        var categoryEntity = _mapper.Map<Category>(dto);

        await _unitOfWork.Repository<Category>().AddAsync(categoryEntity);
        await _unitOfWork.SaveAsync();
        return categoryEntity.Id;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var category = await _unitOfWork.Repository<Category>()
            .GetAsync(x => x.Id == id);

        if (category is null)
            return false;

        _unitOfWork.Repository<Category>().Delete(category);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<CategoryForResultDto> GetByIdAsync(long id)
    {
        var category = await _unitOfWork.Repository<Category>()
            .GetAsync(x => x.Id == id);

        if (category is null)
            throw new Exception("Category topilmadi.");

        return _mapper.Map<CategoryForResultDto>(category);
    }

    public async Task<bool> UpdateAsync(long id, CategoryForUpdateDto dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var category = await _unitOfWork.Repository<Category>()
            .GetAsync(x => x.Id == id);

        if (category is null)
            return false;

        _mapper.Map(dto, category);

        _unitOfWork.Repository<Category>().Update(category);

        return await _unitOfWork.SaveAsync();
    }

}
