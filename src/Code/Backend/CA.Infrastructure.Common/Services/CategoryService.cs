using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Domain.Interfaces.Services;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Common.Services
{
  public class CategoryService : RService<CategoryDTO, int,
                                          MenuCategory, ICategoryRepository<PatosaDbContext>,
                                          PatosaDbContext>, ICategoryService
  {
    public CategoryService(IMapper mapper,
                           IUnitOfWork<PatosaDbContext> unitOfWork,
                           ICategoryRepository<PatosaDbContext> categoryRepository) : base(mapper, unitOfWork, categoryRepository) { }
    public async Task<CategoryDTO> FindCategoryAsync(int id, CancellationToken cancellationToken = default) =>
      await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync(CancellationToken cancellationToken = default) =>
      await GetAllAsync(cancellationToken);
  }
}
