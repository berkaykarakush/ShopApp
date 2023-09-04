using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            //Product
            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ProductVM, List<Product>>().ReverseMap();
            CreateMap<EntityLayer.PageInfo, PageInfoVM>().ReverseMap();
            CreateMap<ListProductQueryResponse, ListProductVM>().ReverseMap();
            CreateMap<ShopCategoryListQueryResponse, ListProductVM>().ReverseMap();
            CreateMap<ShopDetailsQueryResponse, ProductDetailModel>().ReverseMap();
            CreateMap<ShopSearchQueryResponse, ListProductVM>().ReverseMap();
            CreateMap<TopSalesListQueryResponse, ProductListViewModel>().ReverseMap();
            CreateMap<HomeIndexQueryResponse, ProductListViewModel>().ReverseMap();
            CreateMap<EditProductQueryResponse, EditProductVM>().ReverseMap();
            CreateMap<EditProductCommandResponse, EditProductVM>().ReverseMap();
            CreateMap<CreateProductQueryResponse, CreateProductVM>().ReverseMap();
            CreateMap<CreateProductCommandResponse, CreateProductVM>().ReverseMap();
            CreateMap<ShopBrandListQueryResponse, ListProductVM>().ReverseMap();

            //Category
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<EditCategoryQueryResponse, CategoryVM>().ReverseMap();
            CreateMap<EditCategoryCommandResponse, CategoryVM>().ReverseMap();
            CreateMap<ListCategoryQueryResponse, CategoryListViewModel>().ReverseMap();

            //Category2
            CreateMap<CreateCategory2QueryResponse, CreateCategory2VM>().ReverseMap();
            CreateMap<ListCategory2QueryResponse, Category2ListVM>().ReverseMap();
            CreateMap<Category2, Category2VM>().ReverseMap();
            CreateMap<EditCategory2QueryResponse, EditCategory2VM>().ReverseMap();
            CreateMap<ShopCategory2ListQueryResponse, ListProductVM>().ReverseMap();
            //Account
            CreateMap<LoginQueryResponse, LoginModel>().ReverseMap();

            //Cart
            CreateMap<CartIndexQueryResponse, CartModel>().ReverseMap();
            CreateMap<CartItem, CartItemModel>().ReverseMap();
            CreateMap<CheckoutQueryResponse, OrderModel>().ReverseMap();
            CreateMap<Cart, CartModel>().ReverseMap();

            //Campaign
            CreateMap<Campaign, HomeSliderVM>().ReverseMap();
            CreateMap<Campaign, CreateCampaignVM>().ReverseMap();
            CreateMap<ListCampaignQueryResponse, ListCampaignVM>().ReverseMap();
            CreateMap<EditCampaignQueryResponse, EditCampaignVM>().ReverseMap();

            //User
            CreateMap<UserAddress, UserAddressModel>().ReverseMap();

            //Brand
            CreateMap<Brand, BrandVM>().ReverseMap();
            CreateMap<ListBrandQueryResponse, ListBrandVM>().ReverseMap();
            CreateMap<UpdateBrandQueryResponse, UpdateBrandVM>().ReverseMap();
            CreateMap<Brand, UpdateBrandVM>().ReverseMap();


            //Comment
            CreateMap<Comment, CommentVM>().ReverseMap();
            CreateMap<Comment, CreateCommentVM>().ReverseMap();
            CreateMap<Comment, EditCommentVM>().ReverseMap();
            CreateMap<ListCommentQueryResponse, ListCommentVM>().ReverseMap();
            CreateMap<EditCommentQueryResponse, EditCommentVM>().ReverseMap();
            CreateMap<ProductDetailModel, CreateCommentVM>().ReverseMap();
            CreateMap<ProductDetailModel, CommentVM>().ReverseMap();

            //Seller
            CreateMap<SellerRegisterQueryResponse, SellerRegisterModel>().ReverseMap();

            //Store
            CreateMap<Store, StoreVM>().ReverseMap();
            CreateMap<ListStoreQueryResponse, ListStoreVM>().ReverseMap();
            CreateMap<EditStoreQueryResponse, EditStoreVM>().ReverseMap();
        }
    }
}
