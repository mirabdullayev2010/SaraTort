using AutoMapper;
using SaraTort.BLL.DTOs.Cake;
using SaraTort.BLL.DTOs.CartItem;
using SaraTort.BLL.DTOs.Category;
using SaraTort.BLL.DTOs.Order;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Domain.Entities.Orders;
using OrderItemForResultDto = SaraTort.BLL.DTOs.Order.OrderItemForResultDto;

namespace SaraTort.BLL.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Category mappers
        CreateMap<CategoryForCreateDto, Category>();
        CreateMap<CategoryForUpdateDto, Category>();
        CreateMap<Category, CategoryForResultDto>();

        // Cake mappers
        CreateMap<CakeForCreateDto, Cake>();
        CreateMap<CakeForUpdateDto, Cake>();
        CreateMap<Cake, CakeForResultDto>();

        // CartItem mappers
        CreateMap<CartItemForCreateDto, CartItem>();
        CreateMap<CartItemForUpdateDto, CartItem>();
        CreateMap<CartItem, CartItemForResultDto>();

        // Order & OrderItem mappers
        CreateMap<OrderForCreateDto, Order>();
        CreateMap<Order, OrderForResultDto>();
        CreateMap<OrderForCreateDto, Order>();
        CreateMap<OrderItem, OrderForResultDto>();
        CreateMap<OrderItem, OrderItemForResultDto>();
    }
}