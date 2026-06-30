using SaraTort.BLL.DTOs.OrderItem;
using SaraTort.Domain.Entities.Orders;
using SaraTort.Shared.DTOs.OrderItem;

namespace SaraTort.BLL.Interfaces;

public interface IOrderItemService
    : ICrudService<OrderItem, OrderItemForCreateDto, OrderItemForUpdateDto, OrderItemForResultDto>
{
}