using AutoMapper;

using CA.Core.DTO;
using CA.Core.Entities;

namespace CA.Infrastructure.Mappings
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      /* Artículos. */
      CreateMap<Article, ArticleDTO>().ReverseMap();
      CreateMap<CreateArticleDTO, Article>().ReverseMap();
      CreateMap<UpdateArticleDTO, Article>().ReverseMap();
      CreateMap<DeleteArticleDTO, Article>().ReverseMap();

      /* Sucursales. */
      CreateMap<Store, StoreDTO>().ReverseMap();
      CreateMap<CreateStoreDTO, Store>().ReverseMap();
      CreateMap<UpdateStoreDTO, Store>().ReverseMap();
      CreateMap<DeleteStoreDTO, Store>().ReverseMap();

      /* Marcas de artículo. */
      CreateMap<BrandDTO, Brand>().ReverseMap();
      CreateMap<CreateBrandDTO, Brand>().ReverseMap();
      CreateMap<UpdateBrandDTO, Brand>().ReverseMap();
      CreateMap<DeleteBrandDTO, Brand>().ReverseMap();

      /* Proveedores. */
      CreateMap<SupplierDTO, Supplier>().ReverseMap();
      CreateMap<CreateSupplierDTO, Supplier>().ReverseMap();
      CreateMap<UpdateSupplierDTO, Supplier>().ReverseMap();
      CreateMap<DeleteSupplierDTO, Supplier>().ReverseMap();

      /* Categorías. */
      CreateMap<CategoryDTO, MenuCategory>().ReverseMap();
      CreateMap<MenuDTO, MenuSystem>().ReverseMap();

      /* Usuarios (Pendiente...). */
    }
  }
}
