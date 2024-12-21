using MediatR;

namespace E_Association.Core.Features.Associations.Commands.Request
{
    public class ApplyToAssociationCommand : IRequest<string>
    {
        public ApplyToAssociationCommand(string _applicantUserName, string _associationName, int _getCashInMonth)
        {
            this.applicantName = _applicantUserName;
            this.associationName = _associationName;
            this.getCashInMonth = _getCashInMonth;
        }
         
        public string applicantName { set; get; }
        public string associationName { set; get; }
        public int getCashInMonth { set; get; }

    }
}