using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, BranchResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IValidator<CreateBranchCommand> _validator;
        private readonly IMapper _mapper;
        public CreateBranchHandler(SalesTrackerDB data, IValidator<CreateBranchCommand> validator, IMapper mapper)
        {
            _data = data;
            _validator = validator;
            _mapper = mapper;
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

            var existingBranch = await _data.Branches.Include(b => b.Address).FirstOrDefaultAsync(b => b.BranchNumber.Equals(request.BranchNumber)
                    && b.Address.StreetName.ToUpper().Equals(request.StreetName.ToUpper())
                    && b.Address.StreetNumber.Equals(request.StreetNumber));
            if (existingBranch != null) {
                result.SetError($"Ya existe una sucursal en la misma direccion con el nro de local {request.BranchNumber}", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var newAddress = _mapper.Map<Address>(request);
            newAddress.Apartment = "-";
            newAddress.UserId = null;
            var newBranch = _mapper.Map<Branch>(request);

            newBranch.Address = newAddress;
            
            _data.Branches.Add(newBranch);
            await _data.SaveChangesAsync();

            result.Branch = _mapper.Map<BranchDto>(newBranch);
            result.Message = "Sucursal registrada con éxito";

            return result;
        }
    }
}
