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
  public interface ICustomerRepository<TContext> : IBaseRepository<Customer, TContext>
    where TContext : DbContext, new()
  {
    Task<IEnumerable<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default);
    Task<Customer> GetCustomerAsync(int id, CancellationToken cancellationToken = default);
    Task<Customer> SingleCustomerAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default);
    Task<IEnumerable<Customer>> FilterCustomerAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddCustomerAsync(Customer obj, CancellationToken cancellationToken = default);
    Task AddRangeCustomerAsync(IEnumerable<Customer> obj, CancellationToken cancellationToken = default);
    void UpdateCustomer(Customer obj);
    void DeleteCustomer(Customer obj);
  }
}