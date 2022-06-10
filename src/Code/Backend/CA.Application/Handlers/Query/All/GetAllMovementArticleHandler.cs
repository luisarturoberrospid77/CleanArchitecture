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
    public class GetAllMovementArticleHandler : IRequestHandler<GetAllMovementArticleQuery, ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IModelHelper _modelHelper;
        private readonly IMovementArticleService _movementService;
        public GetAllMovementArticleHandler(IMovementArticleService movementService, IMapper mapper, IModelHelper modelHelper, IUriService uriService) =>
            (_mapper, _uriService, _modelHelper, _movementService) = (mapper, uriService, modelHelper, movementService);
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Handle(GetAllMovementArticleQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<MovementArticle, bool>> _expressionLambda = null;
            var _validFilter = _mapper.Map<GetAllMovementArticleParameter>(request);

            //filtered fields security & limit to fields in view model
            if (!string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.ValidateModelFields<MovementArticleDTO>(_validFilter.Fields);

            //default fields from view model
            if (string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.GetModelFields<MovementArticleDTO>();

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
                        new WhereFilter { Field = "OriginStoreName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "SupplierName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "PostingStoreName", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } },
                        new WhereFilter { Field = "Comments", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } }
                    }
                };
                _expressionLambda = QueryBuilder.BuildExpressionLambda<MovementArticle>(_newFilter, new BuildExpressionOptions() { ParseDatesAsUtc = false });
            }

            var _resultPaged = await _movementService.GetPagedMovementArticlesAsync(_validFilter.PageNumber, _validFilter.PageSize, _expressionLambda, _validFilter.Fields, _validFilter.OrderBy, cancellationToken);
            return new ApiResponse<MetaData<ShapedEntityDTO>>(_mapper.Map<PagedList<ShapedEntityDTO>, MetaData<ShapedEntityDTO>>(new PagedList<ShapedEntityDTO>(_resultPaged, _validFilter.PageNumber, _validFilter.PageSize, _movementService.RowCount, _uriService, (string.IsNullOrEmpty(request.Fields)) ? "" : _validFilter.Fields, string.IsNullOrEmpty(request.OrderBy) ? "" : _validFilter.OrderBy, string.IsNullOrEmpty(request.Search) ? "" : _validFilter.Search, request.Route)));
        }
    }
}
