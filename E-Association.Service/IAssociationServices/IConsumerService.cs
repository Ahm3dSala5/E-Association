using Domain.DTOs.Users;
using Domain.Entities.Securities;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IConsumerService
    {
        ValueTask<IEnumerable<ApplicationUser>> Paginationsync(int pageSize, int itemPerPage);
        ValueTask<ApplicationUser> GetOneAsync(string userName);
        ValueTask<List<ApplicationUser>> GetAllUserAsync();
    }
}
