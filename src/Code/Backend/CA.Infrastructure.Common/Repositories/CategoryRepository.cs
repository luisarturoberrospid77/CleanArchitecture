﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;
using CA.Domain.Interfaces.Repository;
using CA.Infrastructure.Persistence.Data;
using CA.Infrastructure.Persistence.Repository.Base;

namespace CA.Infrastructure.Common.Repositories
{
    public class CategoryRepository : BaseRepository<MenuCategory, int, PatosaDbContext>,
                                        ICategoryRepository<PatosaDbContext>
    {
        public CategoryRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task<IEnumerable<MenuCategory>> FilterCategoryAsync(Expression<Func<MenuCategory, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<MenuCategory>> GetCategoriesAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<MenuCategory> SingleCategoryAsync(Expression<Func<MenuCategory, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public async Task<MenuCategory> GetCategoryAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<IEnumerable<MenuCategory>> GetPagedCategoriesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default) =>
            await GetPagedAsync(pageNumber, pageSize, cancellationToken);
    }
}
