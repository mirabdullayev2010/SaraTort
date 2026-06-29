using SaraTort.BLL.DTOs.Order;
using SaraTort.Domain.Entities.Orders;

namespace SaraTort.BLL.Interfaces;

public interface IOrderService
    : ICrudService<Order, OrderForCreateDto, OrderForUpdateDto, OrderForResultDto>
{
}