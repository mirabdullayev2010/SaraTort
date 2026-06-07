using SaraTort.BLL.DTOs.Order;
using SaraTort.BLL.Interfaces;
using SaraTort.Domain.Entities.Orders;
using SaraTort.Shared.DTOs.OrderItem;

namespace SaraTort.BLL.Interface;

public interface IOrderItemService : ICrudService<OrderItem, OrderItemForCreateDto, OrderItemForUpdateDto, OrderItemForResultDto>
{

}
