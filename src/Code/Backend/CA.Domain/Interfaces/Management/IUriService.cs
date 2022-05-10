using System;

using CA.Domain.Parameters;

namespace CA.Domain.Interfaces.Management
{
    public interface IUriService
    {
        Uri GetPageUri(RequestParameter filter, string route);
    }
}
