using System;

using Microsoft.EntityFrameworkCore;

namespace CA.Core.Interfaces.Base
{
  public interface IDbFactory<TContext> : IDisposable where TContext : DbContext, new()
  {
    TContext Init();
  }
}
