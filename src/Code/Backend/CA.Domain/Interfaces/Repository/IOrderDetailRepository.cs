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
  public interface IOrderDetailRepository<TContext> : IBaseRepository<OrderDetail, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<OrderDetail>> GetOrderDetailAsync(CancellationToken cancellationToken = default);
    Task<OrderDetail> GetOrderDetailAsync(int id, CancellationToken cancellationToken = default);
    Task<OrderDetail> SingleOrderDetailAsync(Expression<Func<OrderDetail, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderDetail>> FilterOrderDetailAsync(Expression<Func<OrderDetail, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddOrderDetailAsync(OrderDetail obj, CancellationToken cancellationToken = default);
    Task AddRangeOrderDetailAsync(IEnumerable<OrderDetail> obj, CancellationToken cancellationToken = default);
    void UpdateOrderDetail(OrderDetail obj);
    void DeleteOrderDetail(OrderDetail obj);
  }
}
