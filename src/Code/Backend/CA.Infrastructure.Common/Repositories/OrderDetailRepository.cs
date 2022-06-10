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
    public class OrderDetailRepository : BaseRepository<OrderDetail, int, PatosaDbContext>,
                                            IOrderDetailRepository<PatosaDbContext>
    {
        public OrderDetailRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddOrderDetailAsync(OrderDetail obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeOrderDetailAsync(IEnumerable<OrderDetail> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteOrderDetail(OrderDetail obj) => Delete(obj);
        public async Task<IEnumerable<OrderDetail>> FilterOrderDetailAsync(Expression<Func<OrderDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<OrderDetail> GetOrderDetailAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<OrderDetail> SingleOrderDetailAsync(Expression<Func<OrderDetail, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateOrderDetail(OrderDetail obj) => Update(obj);
    }
}
