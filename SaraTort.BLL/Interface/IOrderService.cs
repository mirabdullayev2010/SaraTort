using SaraTort.BLL.DTOs.Order;
using SaraTort.Domain.Entities.Orders;

namespace SaraTort.BLL.Interfaces;

public interface IOrderService
    : ICroudService<Order, OrderForCreateDto, OrderForUpdateDto, OrderForResultDto>
{
}