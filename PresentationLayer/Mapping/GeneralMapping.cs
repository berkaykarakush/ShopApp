using AutoMapper;
using DataAccessLayer.CQRS.Commands;
using DataAccessLayer.CQRS.Queries;
using EntityLayer;
using PresentationLayer.Areas.Admin.Models;
using PresentationLayer.Areas.Seller.Models;
using PresentationLayer.Identity;
using PresentationLayer.Models;

namespace PresentationLayer.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            #region Product
            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<ProductVM, List<Product>>().ReverseMap();
            CreateMap<EntityLayer.PageInfo, PageInfoVM>().ReverseMap();
            CreateMap<AdminListProductQueryResponse, ListProductVM>().ReverseMap();
            CreateMap<ShopCategoryListQueryResponse, ListProductVM>().ReverseMap();
            CreateMap<ShopStoreListQueryResponse, ListProductVM>().ReverseMap();
            CreateMap<ShopDetailsQueryResponse, ProductDetailModel>().ReverseMap();
            CreateMap<ShopSearchQueryResponse, ListProductVM>().ReverseMap();
            CreateMap<TopSalesListQueryResponse, ProductListViewModel>().ReverseMap();
            CreateMap<HomeIndexQueryResponse, ProductListViewModel>().ReverseMap();
            CreateMap<AdminEditProductQueryResponse, EditProductVM>().ReverseMap();
            CreateMap<AdminEditProductCommandResponse, EditProductVM>().ReverseMap();
            CreateMap<AdminCreateProductQueryResponse, CreateProductVM>().ReverseMap();
            CreateMap<AdminCreateProductCommandResponse, CreateProductVM>().ReverseMap();
            CreateMap<ShopBrandListQueryResponse, ListProductVM>().ReverseMap();

            //Seller
            CreateMap<SellerProductVM, Product>().ReverseMap(); 
            CreateMap<SellerListProductQueryResponse, SellerListProductVM>().ReverseMap(); 
            CreateMap<SellerCreateProductQueryResponse, SellerCreateProductVM>().ReverseMap(); 
            CreateMap<SellerEditProductQueryResponse, SellerEditProductVM>().ReverseMap(); 

            //Admin
            #endregion

            #region Category
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<EditCategoryQueryResponse, CategoryVM>().ReverseMap();
            CreateMap<EditCategoryCommandResponse, CategoryVM>().ReverseMap();
            CreateMap<ListCategoryQueryResponse, CategoryListViewModel>().ReverseMap();
            #endregion

            #region Category2
            CreateMap<CreateCategory2QueryResponse, CreateCategory2VM>().ReverseMap();
            CreateMap<ListCategory2QueryResponse, Category2ListVM>().ReverseMap();
            CreateMap<Category2, Category2VM>().ReverseMap();
            CreateMap<EditCategory2QueryResponse, EditCategory2VM>().ReverseMap();
            CreateMap<ShopCategory2ListQueryResponse, ListProductVM>().ReverseMap();
            #endregion

            #region Account
            CreateMap<LoginQueryResponse, LoginModel>().ReverseMap();
            #endregion

            #region Cart
            CreateMap<CartIndexQueryResponse, CartModel>().ReverseMap();
            CreateMap<CartItem, CartItemModel>().ReverseMap();
            CreateMap<CheckoutQueryResponse, CreateOrderVM>().ReverseMap();
            CreateMap<Cart, CartModel>().ReverseMap();
            #endregion

            #region Campaign
            CreateMap<Campaign, HomeSliderVM>().ReverseMap();
            CreateMap<Campaign, CreateCampaignVM>().ReverseMap();
            CreateMap<ListCampaignQueryResponse, ListCampaignVM>().ReverseMap();
            CreateMap<EditCampaignQueryResponse, EditCampaignVM>().ReverseMap();
            #endregion

            #region User
            CreateMap<UserAddress, UserAddressModel>().ReverseMap();
            #endregion

            #region Brand
            CreateMap<Brand, BrandVM>().ReverseMap();
            CreateMap<ListBrandQueryResponse, ListBrandVM>().ReverseMap();
            CreateMap<UpdateBrandQueryResponse, UpdateBrandVM>().ReverseMap();
            CreateMap<Brand, UpdateBrandVM>().ReverseMap();
            #endregion

            #region Comment
            CreateMap<Comment, CommentVM>().ReverseMap();
            CreateMap<Comment, CreateCommentVM>().ReverseMap();
            CreateMap<Comment, EditCommentVM>().ReverseMap();
            CreateMap<ListCommentQueryResponse, ListCommentVM>().ReverseMap();
            CreateMap<EditCommentQueryResponse, EditCommentVM>().ReverseMap();
            CreateMap<ProductDetailModel, CreateCommentVM>().ReverseMap();
            CreateMap<ProductDetailModel, CommentVM>().ReverseMap();
            #endregion

            #region Seller
            CreateMap<SellerRegisterQueryResponse, SellerRegisterModel>().ReverseMap();
            #endregion

            #region Store
            CreateMap<Store, StoreVM>().ReverseMap();
            CreateMap<AdminListStoreQueryResponse, ListStoreVM>().ReverseMap();
            CreateMap<AdminEditStoreQueryResponse, EditStoreVM>().ReverseMap();
            CreateMap<SellerStoreIndexQueryResponse, StoreIndexVM>().ReverseMap();
            CreateMap<ShopStoreHomeQueryResponse, StoreHomeVM>().ReverseMap();
            #endregion

            #region Order
            //Customer
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<Order, CreateOrderVM>().ReverseMap();
            CreateMap<OrderItem, OrderItemModel>().ReverseMap();
            CreateMap<GetOrdersCommandResponse, OrderListModel>().ReverseMap();

            //Admin
            CreateMap<AdminOrderVM, Order>().ReverseMap();
            CreateMap<AdminListOrderQueryResponse, AdminListOrderVM>().ReverseMap();
            CreateMap<AdminOrderItemVM, OrderItem>().ReverseMap();
            CreateMap<AdminEditOrderQueryResponse, AdminOrderVM>().ReverseMap();

            //Seller
            CreateMap<SellerOrderVM, Order>().ReverseMap();
            CreateMap<SellerOrderItemVM, OrderItem>().ReverseMap();
            CreateMap<SellerListOrderQueryResponse, SellerListOrderVM>().ReverseMap();
            #endregion
        }
    }
}
