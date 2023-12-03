using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, BranchResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        public DeleteBranchHandler(SalesTrackerDB data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }

        public async Task<BranchResult> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var result = new BranchResult();
            if (request.BranchId < 1) {
                result.SetError("No existen sucursales con ids menores a 1", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var branchToUpdate = await _data.Branches.Include(b => b.Address)
                .FirstOrDefaultAsync(b => b.BranchId.Equals(request.BranchId));
            if (branchToUpdate == null) {
                result.SetError($"No existe una sucursal con id {request.BranchId}", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            //TODO: Elimina branch pero no elimina addrees
            _data.Branches.Remove(branchToUpdate);
            await _data.SaveChangesAsync();

            BranchDto deletedBranch = new BranchDto {
                BranchId = request.BranchId,
                Name = branchToUpdate.Name,
                BranchNumber = branchToUpdate.BranchNumber,
                AddressId = branchToUpdate.AddressId,
                StreetName = branchToUpdate.Address.StreetName,
                StreetNumber = branchToUpdate.Address.StreetNumber
            };
            result.Branch = deletedBranch;
            result.Message = "Sucursal eliminada exitosamente";

            return result;
        }
    }
}
