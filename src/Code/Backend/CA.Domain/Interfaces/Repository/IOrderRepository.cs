using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using CA.Domain.Entities;
using CA.Domain.Interfaces.Base;

namespace CA.Domain.Interfaces.Repository
{
    public interface IOrderRepository<TContext> : IBaseRepository<Order, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<Order>> GetOrderAsync(CancellationToken cancellationToken = default);
        Task<Order> GetOrderAsync(int id, CancellationToken cancellationToken = default);
        Task<Order> SingleOrderAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<Order>> FilterOrderAsync(Expression<Func<Order, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddOrderAsync(Order obj, CancellationToken cancellationToken = default);
        Task AddRangeOrderAsync(IEnumerable<Order> obj, CancellationToken cancellationToken = default);
        void UpdateOrder(Order obj);
        void DeleteOrder(Order obj);
    }
}
