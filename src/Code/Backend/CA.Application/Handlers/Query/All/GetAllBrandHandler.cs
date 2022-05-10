using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using MediatR;
using Utilities;
using AutoMapper;

using CA.Domain.DTO;
using CA.Domain.Custom;
using CA.Domain.Wrappers;
using CA.Domain.Entities;
using CA.Application.Queries;
using CA.Domain.Entities.Base;
using CA.Domain.Interfaces.Services;
using CA.Domain.Interfaces.Management;

namespace CA.Application.Handlers.Query
{
    public class GetAllBrandHandler : IRequestHandler<GetAllBrandQuery, ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IModelHelper _modelHelper;
        private readonly IBrandService _brandService;
        public GetAllBrandHandler(IBrandService brandService, IMapper mapper, IModelHelper modelHelper, IUriService uriService) =>
            (_mapper, _uriService, _modelHelper, _brandService) = (mapper, uriService, modelHelper, brandService);
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Brand, bool>> _expressionLambda = null;
            var _validFilter = _mapper.Map<GetAllBrandParameter>(request);

            // Filtered fields security & limit to fields in view model
            if (!string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.ValidateModelFields<BrandDTO>(_validFilter.Fields);

            // Default fields from view model
            if (string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.GetModelFields<BrandDTO>();

            // Create search criteria, according to the entity of the Database context.
            if (!string.IsNullOrEmpty(_validFilter.Search))
            {
                var _newFilter = new WhereFilter()
                {
                    Condition = GroupOp.OR,
                    Rules = new List<WhereFilter>()
                    {
                        new WhereFilter { Field = "Name", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } }
                    }
                };
                _expressionLambda = QueryBuilder.BuildExpressionLambda<Brand>(_newFilter, new BuildExpressionOptions() { ParseDatesAsUtc = false });
            }

            var _resultPaged = await _brandService.GetPagedBrandsAsync(_validFilter.PageNumber, _validFilter.PageSize, cancellationToken, _expressionLambda, _validFilter.Fields, _validFilter.OrderBy);
            return new ApiResponse<MetaData<ShapedEntityDTO>>(_mapper.Map<PagedList<ShapedEntityDTO>, MetaData<ShapedEntityDTO>>(new PagedList<ShapedEntityDTO>(_resultPaged, _validFilter.PageNumber, _validFilter.PageSize, _brandService.RowCount, _uriService, string.IsNullOrEmpty(request.Fields) ? "" : _validFilter.Fields, string.IsNullOrEmpty(request.OrderBy) ? "" : _validFilter.OrderBy, string.IsNullOrEmpty(request.Search) ? "" : _validFilter.Search, request.Route)));
        }
    }
}
