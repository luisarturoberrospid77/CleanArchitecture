using System;
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
    public class OrderRepository : BaseRepository<Order, int, PatosaDbContext>,
                                                    IOrderRepository<PatosaDbContext>
    {
        public OrderRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddOrderAsync(Order obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeOrderAsync(IEnumerable<Order> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteOrder(Order obj) => Delete(obj);
        public async Task<IEnumerable<Order>> FilterOrderAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<Order>> GetOrderAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<Order> GetOrderAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<Order> SingleOrderAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateOrder(Order obj) => Update(obj);
    }
}
