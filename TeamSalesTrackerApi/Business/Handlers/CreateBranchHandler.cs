using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Branches;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, BranchResult>
    {
        private readonly IValidator<CreateBranchCommand> _validator;
        private readonly IBranchService _branchService;
        public CreateBranchHandler(IValidator<CreateBranchCommand> validator, IBranchService service)
        {
            _validator = validator;
            _branchService = service;
        }

        public async Task<BranchResult> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var result = new BranchResult();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid) {
                var errors = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(errors, System.Net.HttpStatusCode.BadRequest);
                return result;
            }

            var existingBranch = await _branchService.Exists(request.BranchNumber, request.StreetName, request.StreetNumber);
            if (existingBranch) {
                result.SetError($"Ya existe una sucursal en la misma direccion con el nro de local {request.BranchNumber}", System.Net.HttpStatusCode.BadRequest);
                return result;
            }

            result.Branch = await _branchService.CreateBranch(request);
            result.Message = "Sucursal registrada con éxito";

            return result;
        }
    }
}
