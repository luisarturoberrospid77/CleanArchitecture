using System;

using Microsoft.EntityFrameworkCore;

namespace CA.Domain.Interfaces.Base
{
    public interface IDbFactory<TContext> : IDisposable where TContext : DbContext, new()
    {
        TContext Init();
    }
}
