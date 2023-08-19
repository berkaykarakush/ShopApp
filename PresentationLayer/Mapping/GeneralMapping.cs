using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using PresentationLayer.Models;
using PresentationLayer.ViewModels;

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


            //Category
            CreateMap<EditCategoryQueryResponse, CategoryVM>().ReverseMap();

            CreateMap<EditCategoryCommandResponse, CategoryVM>().ReverseMap();
        }
    }
}
