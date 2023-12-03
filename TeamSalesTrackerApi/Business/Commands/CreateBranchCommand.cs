using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using TeamSalesTrackerApi.Results.Branches;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class CreateBranchCommand : IRequest<BranchResult>
    {
        public string Name { get; set; }
        public long BranchNumber { get; set; }
        public string StreetName { get; set; }
        public long StreetNumber { get; set; }
        public string ZipCode { get; set; }
    }
}
