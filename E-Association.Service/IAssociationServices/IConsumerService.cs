using Domain.DTOs.Users;
using Domain.Entities.Securities;

namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IConsumerService
    {
        ValueTask<IEnumerable<Consumer>> Paginationsync(int pageSize, int itemPerPage);
        ValueTask<Consumer> GetOneAsync(string userName);
        ValueTask<List<Consumer>> GetAllUserAsync();
    }
}
