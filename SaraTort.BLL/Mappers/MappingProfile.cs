using AutoMapper;
using SaraTort.BLL.DTOs.Cake;
using SaraTort.BLL.DTOs.CakeReview;
using SaraTort.BLL.DTOs.CartItem;
using SaraTort.BLL.DTOs.Category;
using SaraTort.BLL.DTOs.Order;
using SaraTort.BLL.DTOs.OrderItem;
using SaraTort.Domain.Entities;
using SaraTort.Domain.Entities.Catalog;
using SaraTort.Domain.Entities.Orders;
using SaraTort.Shared.DTOs.User;

namespace SaraTort.BLL.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryForCreateDto, Category>();
        CreateMap<CategoryForUpdateDto, Category>();
        CreateMap<Category, CategoryForResultDto>();
                                                                                                                           
        CreateMap<CakeForCreateDto, Cake>();
        CreateMap<CakeForUpdateDto, Cake>();
        CreateMap<Cake, CakeForResultDto>();

        CreateMap<CartItemForCreateDto, CartItem>();
        CreateMap<CartItemForUpdateDto, CartItem>();
        CreateMap<CartItem, CartItemForResultDto>();

        CreateMap<OrderForCreateDto, Order>();
        CreateMap<Order, OrderForResultDto>();
        CreateMap<OrderForCreateDto, Order>();
        CreateMap<Order, OrderForResultDto>();

        CreateMap<OrderItemForCreateDto, orderItem>();
        CreateMap<orderItem, OrderItemForResultDto>();
        CreateMap<OrderItemForCreateDto, orderItem>();
        CreateMap<orderItem, OrderItemForResultDto>();

        CreateMap<CakeReviewForCreateDto, CakeReview>();
        CreateMap<CakeReview, CakeReviewForResultDto>();
        CreateMap<CakeReviewForCreateDto, CakeReview>();
        CreateMap<CakeReview, CakeReviewForResultDto>();

        CreateMap<UserForCreateDto, User>();
        CreateMap<User, UserForResultDto>();
        CreateMap<UserForCreateDto, User>();
        CreateMap<User, UserForResultDto>();
    }
}