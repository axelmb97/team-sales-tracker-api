using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class UpdateBranchCommand : IRequest<BranchResult>
    {
        public long BranchId { get; set; }
        public string Name { get; set; }
        public long BranchNumber { get; set; }
        public long AddressId { get; set; }
        public string StreetName { get; set; }
        public long StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string Apartment { get; set; }
    }
}
