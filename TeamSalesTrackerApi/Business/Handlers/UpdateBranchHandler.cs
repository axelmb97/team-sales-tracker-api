using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, BranchResult>
    {
        
        private readonly IValidator<UpdateBranchCommand> _validator;
        private readonly IBranchService _branchService;
        public UpdateBranchHandler(IValidator<UpdateBranchCommand> validator, IBranchService branchService)
        {
            _validator = validator;
            _branchService = branchService;
        }

        public async Task<BranchResult> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var result = new BranchResult();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid) {
                var errors = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(errors, System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var branchToUpdate = await _branchService.ExistsByBranchIdAndAddressId(request.BranchId, request.AddressId);
            if (!branchToUpdate) {
                result.SetError($"No existe sucursal con id {request.BranchId} y direccion con id {request.AddressId}", System.Net.HttpStatusCode.BadRequest);
                return result;
            }

            result.Branch = await _branchService.UpdateBranch(request);
            result.Message = "Sucursal actualizada correctamente";
            return result;
        }
    }
}
