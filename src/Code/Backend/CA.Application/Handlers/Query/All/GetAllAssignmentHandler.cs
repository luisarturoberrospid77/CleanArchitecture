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
    public class GetAllAssignmentHandler : IRequestHandler<GetAllAssignmentQuery, ApiResponse<MetaData<ShapedEntityDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private readonly IModelHelper _modelHelper;
        private readonly IAssignmentOrderService _assignmentOrderService;
        public GetAllAssignmentHandler(IAssignmentOrderService assignmentOrderService, IMapper mapper, IModelHelper modelHelper, IUriService uriService) =>
            (_mapper, _uriService, _modelHelper, _assignmentOrderService) = (mapper, uriService, modelHelper, assignmentOrderService);
        public async Task<ApiResponse<MetaData<ShapedEntityDTO>>> Handle(GetAllAssignmentQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Assignment, bool>> _expressionLambda = null;
            var _validFilter = _mapper.Map<GetAllAssignmentParameter>(request);

            // Filtered fields security & limit to fields in view model
            if (!string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.ValidateModelFields<AssignmentDTO>(_validFilter.Fields);

            // Default fields from view model
            if (string.IsNullOrEmpty(_validFilter.Fields))
                _validFilter.Fields = _modelHelper.GetModelFields<AssignmentDTO>();

            // Create search criteria, according to the entity of the Database context.
            if (!string.IsNullOrEmpty(_validFilter.Search))
            {
                var _newFilter = new WhereFilter()
                {
                    Condition = GroupOp.OR,
                    Rules = new List<WhereFilter>()
                    {
                        new WhereFilter { Field = "Comments", Operator = WhereConditionsOp.Contains, Data = new[] { _validFilter.Search } }
                    }
                };
                _expressionLambda = QueryBuilder.BuildExpressionLambda<Assignment>(_newFilter, new BuildExpressionOptions() { ParseDatesAsUtc = false });
            }

            var _resultPaged = await _assignmentOrderService.GetPagedAssignmentOrderAsync(_validFilter.PageNumber, _validFilter.PageSize, _expressionLambda, _validFilter.Fields, _validFilter.OrderBy, cancellationToken);
            return new ApiResponse<MetaData<ShapedEntityDTO>>(_mapper.Map<PagedList<ShapedEntityDTO>, MetaData<ShapedEntityDTO>>(new PagedList<ShapedEntityDTO>(_resultPaged, _validFilter.PageNumber, _validFilter.PageSize, _assignmentOrderService.RowCount, _uriService, string.IsNullOrEmpty(request.Fields) ? "" : _validFilter.Fields, string.IsNullOrEmpty(request.OrderBy) ? "" : _validFilter.OrderBy, string.IsNullOrEmpty(request.Search) ? "" : _validFilter.Search, request.Route)));
        }
    }
}
