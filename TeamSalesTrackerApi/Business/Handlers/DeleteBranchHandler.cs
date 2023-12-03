using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, BranchResult>
    {
        private readonly IBranchService _branchService;
        public DeleteBranchHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<BranchResult> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var result = new BranchResult();
            if (request.BranchId < 1) {
                result.SetError("No existen sucursales con ids menores a 1", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var branchToUpdate = await _branchService.ExistsById(request.BranchId);
            if (!branchToUpdate) {
                result.SetError($"No existe una sucursal con id {request.BranchId}", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
           
            result.Branch = await _branchService.DeleteBranch(request.BranchId);
            result.Message = "Sucursal eliminada exitosamente";

            return result;
        }
    }
}
