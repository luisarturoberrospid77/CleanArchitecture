using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;

using CA.Core.DTO;
using CA.Core.Entities;
using CA.Core.Interfaces.Base;
using CA.Core.Interfaces.Services;
using CA.Core.Interfaces.Repository;

using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Services.Base;

namespace CA.Infrastructure.Persistence.Services
{
  public class CategoryService : RService<CategoryDTO, int,
                                          MenuCategory, ICategoryRepository<PatosaDbContext>, PatosaDbContext>, ICategoryService
  {
    public CategoryService(IMapper mapper, IUnitOfWork<PatosaDbContext> unitOfWork, ICategoryRepository<PatosaDbContext> categoryRepository) : base(categoryRepository, unitOfWork, mapper) { }
    public async Task<CategoryDTO> FindCategoryAsync(int id, CancellationToken cancellationToken = default) => await FindAsync(id, cancellationToken);
    public async Task<IEnumerable<CategoryDTO>> GetCategories(CancellationToken cancellationToken = default) => await GetAll(cancellationToken);
  }
}
