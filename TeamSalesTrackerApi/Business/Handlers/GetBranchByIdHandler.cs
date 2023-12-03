using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class GetBranchByIdHandler : IRequestHandler<GetBranchByIdQuery, BranchResult>
    {
        
        private readonly IBranchService _branchService;
        public GetBranchByIdHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<BranchResult> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new BranchResult();
            if (request.BranchId < 1) {
                result.SetError("El id de la sucursal no puede ser menor a 1", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var branch = await _branchService.GetById(request.BranchId);
            if (branch == null) {
                result.SetError($"No existe una sucursal con id {request.BranchId}", System.Net.HttpStatusCode.NotFound);
                return result;
            }
            result.Branch = branch;
            result.Message = "Sucursal recuperada correctamente";
            return result;
        }
    }
}
