using SaraTort.BLL.DTOs.Order;
using SaraTort.Domain.Entities;
using SaraTort.Domain.Entities.Orders;

namespace SaraTort.BLL.Interfaces;

public interface IOrderService : ICrudService<Order, OrderForCreateDto, OrderForUpdateStatusDto, OrderForResultDto>
{
    Task<OrderForResultDto> UpdateStatusAsync(OrderForUpdateStatusDto dto);
}