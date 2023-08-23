using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using PresentationLayer.Identity;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;
using System.Runtime.CompilerServices;

namespace PresentationLayer.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            //Product
            CreateMap<ListProductQueryResponse, ListProductVM>().ReverseMap();

            CreateMap<ShopListQueryResponse, ListProductVM>().ReverseMap();

            CreateMap<EntityLayer.PageInfo, PageInfoVM>().ReverseMap();

            CreateMap<ShopSearchQueryResponse, ListProductVM>().ReverseMap();

            CreateMap<ShopDetailsQueryResponse, ProductDetailModel>().ReverseMap();

            CreateMap<TopSalesListQueryResponse, ProductListViewModel>().ReverseMap();

            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ProductVM, List<Product>>().ReverseMap();
            
            CreateMap<HomeIndexQueryResponse, ProductListViewModel>().ReverseMap();
            
            CreateMap<EditProductQueryResponse, EditProductVM>().ReverseMap();

            CreateMap<EditProductCommandResponse, EditProductVM>().ReverseMap();



            //Category
            CreateMap<EditCategoryQueryResponse, CategoryVM>().ReverseMap();

            CreateMap<EditCategoryCommandResponse, CategoryVM>().ReverseMap();

            //Account
            CreateMap<LoginQueryResponse, LoginModel>().ReverseMap();

            //Cart
            CreateMap<CartIndexQueryResponse, CartModel>().ReverseMap();
            CreateMap<CartItem, CartItemModel>().ReverseMap();
            CreateMap<CheckoutQueryResponse, OrderModel>().ReverseMap();
            CreateMap<Cart, CartModel>().ReverseMap();

            //Campaign
            CreateMap<Campaign, HomeSliderVM>().ReverseMap();

        }
    }
}
