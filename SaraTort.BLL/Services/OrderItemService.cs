using AutoMapper;
using FluentValidation;
using SaraTort.BLL.DTOs.OrderItem;
using SaraTort.BLL.Interfaces;
using SaraTort.DAL.Interfaces;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Domain.Entities.Orders;
using SaraTort.Shared.DTOs.OrderItem;

namespace SaraTort.BLL.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<OrderItemForCreateDto> _createValidator;
    private readonly IValidator<OrderItemForUpdateDto> _updateValidator;

    public OrderItemService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<OrderItemForCreateDto> createValidator,
        IValidator<OrderItemForUpdateDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<long> CreateAsync(OrderItemForCreateDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var OrderItem = _mapper.Map<orderItem>(dto);

        await _unitOfWork.Repository<orderItem>().AddAsync(OrderItem);

        await _unitOfWork.SaveAsync();

        return OrderItem.Id;
    }

    public async Task<bool> UpdateAsync(long id, OrderItemForUpdateDto dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var OrderItem = await _unitOfWork.Repository<orderItem>()
            .GetAsync(x => x.Id == id);

        if (OrderItem is null)
            return false;

        _mapper.Map(dto, OrderItem);

        _unitOfWork.Repository<orderItem>().Update(OrderItem);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var OrderItem = await _unitOfWork.Repository<orderItem>()
            .GetAsync(x => x.Id == id);

        if (OrderItem is null)
            return false;

        _unitOfWork.Repository<orderItem>().Delete(OrderItem);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<OrderItemForResultDto> GetByIdAsync(long id)
    {
        var OrderItem = await _unitOfWork.Repository<orderItem>()
            .GetAsync(
                x => x.Id == id,
                includes: new[]
                {
                    nameof(orderItem),
                    nameof(orderItem)
                });

        if (OrderItem is null)
            throw new Exception("OrderItem topilmadi.");

        return _mapper.Map<OrderItemForResultDto>(OrderItem);
    }

    public async Task<IEnumerable<OrderItemForResultDto>> GetAllAsync()
    {
        var OrderItems = await _unitOfWork.Repository<orderItem>()
            .GetAllAsync(
                includes: new[]
                {
                    nameof(orderItem),
                    nameof(orderItem)
                });

        return _mapper.Map<IEnumerable<OrderItemForResultDto>>(OrderItems);
    }
}