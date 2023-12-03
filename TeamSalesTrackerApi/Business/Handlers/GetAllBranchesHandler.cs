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
    public class GetAllBranchesHandler : IRequestHandler<GetAllBranchesQuery, BranchesResult>
    {
        private readonly IBranchService _branchService;
        public GetAllBranchesHandler(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<BranchesResult> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var result = new BranchesResult();

            var branches = await _branchService.GetAll();
            if (branches == null) {
                result.SetError("No se encuentran sucursales disponibles", System.Net.HttpStatusCode.NotFound);
                return result;
            }
            result.Branches = branches;
            result.Message = "Sucursales recuperadas correctamente";
            return result;
        }
    }
}
