using System;

using Microsoft.AspNetCore.WebUtilities;

using CA.Domain.Parameters;
using CA.Domain.Interfaces.Management;

namespace CA.Infrastructure.Common.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri) => _baseUri = baseUri;
        public Uri GetPageUri(RequestParameter filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var _modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "PageNumber", filter.PageNumber.ToString());
            _modifiedUri = QueryHelpers.AddQueryString(_modifiedUri, "PageSize", filter.PageSize.ToString());

            if (!string.IsNullOrEmpty(filter.Search))
                _modifiedUri = QueryHelpers.AddQueryString(_modifiedUri, "Search", filter.Search.Trim());

            if (!string.IsNullOrEmpty(filter.Fields))
                _modifiedUri = QueryHelpers.AddQueryString(_modifiedUri, "Fields", filter.Fields.Trim());

            if (!string.IsNullOrEmpty(filter.OrderBy))
                _modifiedUri = QueryHelpers.AddQueryString(_modifiedUri, "OrderBy", filter.OrderBy.Trim());

            return new Uri(_modifiedUri);
        }
    }
}
