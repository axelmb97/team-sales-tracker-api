using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class GetAllBranchesHandler : IRequestHandler<GetAllBranchesQuery, BranchesResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        public GetAllBranchesHandler(SalesTrackerDB data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<BranchesResult> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var result = new BranchesResult();

            var branches = await _data.Branches.Include(b => b.Address).ToListAsync();
            if (branches == null) {
                result.SetError("No se encuentran sucursales disponibles", System.Net.HttpStatusCode.NotFound);
                return result;
            }
            foreach (var b in branches) {
                result.Branches.Add(_mapper.Map<BranchDto>(b));
            }
            result.Message = "Sucursales recuperadas correctamente";
            return result;
        }
    }
}
