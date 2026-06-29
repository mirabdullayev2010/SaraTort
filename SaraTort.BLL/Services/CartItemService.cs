using AutoMapper;
using FluentValidation;
using SaraTort.BLL.DTOs.CartItem;
using SaraTort.BLL.Interfaces;
using SaraTort.DAL.Interfaces;
using SaraTort.Domain.Entities.Orders;

namespace SaraTort.BLL.Services;

public class CartItemService : ICartItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<CartItemForCreateDto> _createValidator;
    private readonly IValidator<CartItemForUpdateDto> _updateValidator;

    public CartItemService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<CartItemForCreateDto> createValidator,
        IValidator<CartItemForUpdateDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<long> CreateAsync(CartItemForCreateDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cartItem = _mapper.Map<CartItem>(dto);

        await _unitOfWork.Repository<CartItem>().AddAsync(cartItem);

        await _unitOfWork.SaveAsync();

        return cartItem.Id;
    }

    public async Task<bool> UpdateAsync(long id, CartItemForUpdateDto dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cartItem = await _unitOfWork.Repository<CartItem>()
            .GetAsync(x => x.Id == id);

        if (cartItem is null)
            return false;

        _mapper.Map(dto, cartItem);

        _unitOfWork.Repository<CartItem>().Update(cartItem);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var cartItem = await _unitOfWork.Repository<CartItem>()
            .GetAsync(x => x.Id == id);

        if (cartItem is null)
            return false;

        _unitOfWork.Repository<CartItem>().Delete(cartItem);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<CartItemForResultDto> GetByIdAsync(long id)
    {
        var cartItem = await _unitOfWork.Repository<CartItem>()
            .GetAsync(x => x.Id == id);

        if (cartItem is null)
            throw new Exception("CartItem topilmadi.");

        return _mapper.Map<CartItemForResultDto>(cartItem);
    }

    public async Task<IEnumerable<CartItemForResultDto>> GetAllAsync()
    {
        var cartItems = await _unitOfWork.Repository<CartItem>()
            .GetAllAsync();

        return _mapper.Map<IEnumerable<CartItemForResultDto>>(cartItems);
    }
}