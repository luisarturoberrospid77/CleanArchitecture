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
      CreateMap<Article, ArticleDTO>();
      CreateMap<ArticleDTO, Article>();

      /* Sucursales. */
      CreateMap<Store, StoreDTO>();
      CreateMap<StoreDTO, Store>();

      /* Tipos de artículo. */
      CreateMap<ProductType, ProductTypeDTO>();
      CreateMap<ProductTypeDTO, ProductType>();

      /* Usuarios (Pendiente...). */
    }
  }
}
