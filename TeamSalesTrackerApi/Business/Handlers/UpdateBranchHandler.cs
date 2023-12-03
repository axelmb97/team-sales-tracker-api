using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, BranchResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateBranchCommand> _validator;
        public UpdateBranchHandler(SalesTrackerDB data, IMapper mapper, IValidator<UpdateBranchCommand> validator)
        {
            _data = data;
            _mapper = mapper;
            _validator = validator;
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
            var branchToUpdate = await _data.Branches.Include(b => b.Address).FirstOrDefaultAsync(b => b.BranchId.Equals(request.BranchId)
                && b.Address.AddressId.Equals(request.AddressId));
            if (branchToUpdate == null) {
                result.SetError($"No existe sucursal con id {request.BranchId} y direccion con id {request.AddressId}", System.Net.HttpStatusCode.BadRequest);
                return result;
            }

            branchToUpdate.BranchNumber = request.BranchNumber;
            branchToUpdate.Name = request.Name;
            branchToUpdate.Address.StreetName = request.StreetName;
            branchToUpdate.Address.StreetNumber = request.StreetNumber;
            branchToUpdate.Address.ZipCode = request.ZipCode;
            branchToUpdate.Address.Apartment = request.Apartment;
           _data.Branches.Update(branchToUpdate);
            await _data.SaveChangesAsync();

            result.Branch = _mapper.Map<BranchDto>(branchToUpdate);
            result.Message = "Sucursal actualizada correctamente";
            return result;
        }
    }
}
