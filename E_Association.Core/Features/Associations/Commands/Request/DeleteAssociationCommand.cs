using MediatR;

namespace E_Association.Core.Features.Associations.Commands.Request
{
    public class DeleteAssociationCommand :IRequest<string>
    {
        public DeleteAssociationCommand(string associationName)
        {
            this.Name = associationName;
        }
        public string Name { set; get; }
    }
}