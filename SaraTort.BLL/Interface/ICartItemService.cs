using SaraTort.BLL.DTOs.CartItem;
using SaraTort.Domain.Entities.Orders;

namespace SaraTort.BLL.Interfaces;

public interface ICartItemService
    : ICrudService<CartItem, CartItemForCreateDto, CartItemForUpdateDto, CartItemForResultDto>
{
}