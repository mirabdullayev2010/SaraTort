using SaraTort.BLL.DTOs.CartItem;
using SaraTort.BLL.Interfaces;
using SaraTort.Domain.Entities.Orders;

namespace SaraTort.BLL.Interface;

public interface ICartItemService : ICrudService<CartItem, CartItemForCreateDto, CartItemForUpdateDto, CartItemForResultDto>
{

}
