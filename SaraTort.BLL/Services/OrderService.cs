using AutoMapper;
using FluentValidation;
using SaraTort.BLL.DTOs.Category;
using SaraTort.BLL.DTOs.Order;
using SaraTort.BLL.Interfaces;
using SaraTort.DAL.Interfaces;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Domain.Entities.Orders;

namespace SaraTort.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidator<OrderForCreateDto> _createValidator;
    private readonly IValidator<OrderForUpdateDto> _updateValidator;

    public OrderService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IValidator<OrderForCreateDto> createValidator,
        IValidator<OrderForUpdateDto> updateValidator)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<long> CreateAsync(OrderForCreateDto dto)
    {
        var validationResult = await _createValidator.ValidateAsync(dto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        var orderEntity = _mapper.Map<Order>(dto);

        await _unitOfWork.Repository<Order>().AddAsync(orderEntity);
        await _unitOfWork.SaveAsync();
        return orderEntity.Id;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var orderEntity = await _unitOfWork.Repository<Order>()
            .GetAsync(x => x.Id == id);

        if (orderEntity is null)
            return false;

        _unitOfWork.Repository<Order>().Delete(orderEntity);

        return await _unitOfWork.SaveAsync();
    }

    public async Task<OrderForResultDto> GetByIdAsync(long id)
    {
        var orderEntity = await _unitOfWork.Repository<Order>()
            .GetAsync(x => x.Id == id);

        if (orderEntity is null)
            throw new Exception("Order topilmadi.");

        return _mapper.Map<OrderForResultDto>(orderEntity);
    }

    public async Task<bool> UpdateAsync(long id, OrderForUpdateDto dto)
    {
        var validationResult = await _updateValidator.ValidateAsync(dto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderEntity = await _unitOfWork.Repository<Order>()
            .GetAsync(x => x.Id == id);

        if (orderEntity is null)
            return false;

        _mapper.Map(dto, orderEntity);

        _unitOfWork.Repository<Order>().Update(orderEntity);

        return await _unitOfWork.SaveAsync();
    }
}
