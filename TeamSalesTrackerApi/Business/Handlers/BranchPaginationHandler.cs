using FluentValidation;
using MediatR;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Pagination;
using TeamSalesTrackerApi.Services.Implementations;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class BranchPaginationHandler : IRequestHandler<BranchPaginationCommand, PaginationResult<BranchDto>>
    {
        private readonly IBranchService _branchService;
        private readonly IValidator<BranchPaginationCommand> _validator;
        public BranchPaginationHandler(IBranchService branchService, IValidator<BranchPaginationCommand> val
            )
        {
            _branchService = branchService;
            _validator = val;
        }
        public async Task<PaginationResult<BranchDto>> Handle(BranchPaginationCommand request, CancellationToken cancellationToken)
        {
            var result = new PaginationResult<BranchDto>();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid)
            {
                var errors = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(errors, System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var products = await _branchService.GetPaginatedProducts(request);
            result.Result = products;
            result.Message = "Sucursales recuperadas con éxitos";
            return result;
        }
    }
}
