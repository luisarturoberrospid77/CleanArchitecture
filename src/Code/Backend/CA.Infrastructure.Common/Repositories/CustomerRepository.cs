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
    public class CustomerRepository : BaseRepository<Customer, int, PatosaDbContext>,
                                        ICustomerRepository<PatosaDbContext>
    {
        public CustomerRepository(IDbFactory<PatosaDbContext> dbFactory) : base(dbFactory) { }
        public async Task AddCustomerAsync(Customer obj, CancellationToken cancellationToken = default) =>
            await AddAsync(obj, cancellationToken);
        public async Task AddRangeCustomerAsync(IEnumerable<Customer> obj, CancellationToken cancellationToken = default) =>
            await AddRangeAsync(obj, cancellationToken);
        public void DeleteCustomer(Customer obj) => Delete(obj);
        public async Task<IEnumerable<Customer>> FilterCustomerAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterAsync(predicate, cancellationToken);
        public async Task<Customer> GetCustomerAsync(int id, CancellationToken cancellationToken = default) =>
            await GetByIdAsync(id, cancellationToken);
        public async Task<IEnumerable<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default) =>
            await AllAsync(cancellationToken);
        public async Task<IEnumerable<Customer>> GetPagedCustomersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default) =>
            await GetPagedAsync(pageNumber, pageSize, cancellationToken);
        public async Task<Customer> SingleCustomerAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default) =>
            await FilterSingleAsync(predicate, cancellationToken);
        public void UpdateCustomer(Customer obj) => Update(obj);
    }
}
