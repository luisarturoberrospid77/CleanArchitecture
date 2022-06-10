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
    public class GetAllStockArticleHandler : IRequestHandler<GetAllStockArticleQuery, ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IModelHelper _modelHelper;
        private readonly IStockArticleService _stockArticleService;
        public GetAllStockArticleHandler(IStockArticleService stockArticleService, IMapper mapper, IModelHelper modelHelper, IUriService uriService) =>
            (_mapper, _uriService, _modelHelper, _stockArticleService) = (mapper, uriService, modelHelper, stockArticleService);
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Handle(GetAllStockArticleQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<StockArticle, bool>> _expressionLambda = null;
            var _validFilter = _mapper.Map<GetAllStockArticleParameter>(request);

            //filtered fields security & limit to fields in view model
            if (!string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.ValidateModelFields<StockArticleDTO>(_validFilter.Fields);

            //default fields from view model
            if (string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.GetModelFields<StockArticleDTO>();

            // Create search criteria, according to the entity of the Database context.
            if (!string.IsNullOrEmpty(_validFilter.Search))
            {
                var _newFilter = new WhereFilter()
                {
                    Condition = GroupOp.OR,
                    Rules = new List<WhereFilter>()
                    {
                        new WhereFilter { Field = "ArticleShortName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "Description", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "BrandName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "DepartmentName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "ProducttypeName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "StoreName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } }
                    }
                };
                _expressionLambda = QueryBuilder.BuildExpressionLambda<StockArticle>(_newFilter, new BuildExpressionOptions() { ParseDatesAsUtc = false });
            }

            var _resultPaged = await _stockArticleService.GetPagedStockArticlesAsync(_validFilter.PageNumber, _validFilter.PageSize, _expressionLambda, _validFilter.Fields, _validFilter.OrderBy, cancellationToken);
            return new ApiResponse<MetaData<ShapedEntityDTO>>(_mapper.Map<PagedList<ShapedEntityDTO>, MetaData<ShapedEntityDTO>>(new PagedList<ShapedEntityDTO>(_resultPaged, _validFilter.PageNumber, _validFilter.PageSize, _stockArticleService.RowCount, _uriService, (string.IsNullOrEmpty(request.Fields)) ? "" : _validFilter.Fields, string.IsNullOrEmpty(request.OrderBy) ? "" : _validFilter.OrderBy, string.IsNullOrEmpty(request.Search) ? "" : _validFilter.Search, request.Route)));
        }
    }
}
