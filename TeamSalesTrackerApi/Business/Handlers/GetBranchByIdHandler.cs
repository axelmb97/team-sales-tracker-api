using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class GetBranchByIdHandler : IRequestHandler<GetBranchByIdQuery, BranchResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        public GetBranchByIdHandler(SalesTrackerDB data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<BranchResult> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new BranchResult();
            if (request.BranchId < 1) {
                result.SetError("El id de la sucursal no puede ser menor a 1", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var branch = await _data.Branches.Include(b => b.Address).FirstOrDefaultAsync(b => b.BranchId.Equals(request.BranchId));
            if (branch == null) {
                result.SetError($"No existe una sucursal con id {request.BranchId}", System.Net.HttpStatusCode.NotFound);
                return result;
            }
            result.Branch = _mapper.Map<BranchDto>(branch);
            result.Message = "Sucursal recuperada correctamente";
            return result;
        }
    }
}
