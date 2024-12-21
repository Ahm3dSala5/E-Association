using Domain.Entities.Securities;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class ConsumerService : IConsumerService
    {
        private UserManager<ApplicationUser> _userManager;
        public ConsumerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async ValueTask<IEnumerable<ApplicationUser>> Paginationsync(int numPage, int itemPerPage)
        {
            var Users = await _userManager.Users.ToListAsync();
            if (Users is null)
                throw new Exception("Users List is Empty");

            var allUserCount = Users.Count();
            var skiped = (allUserCount / itemPerPage) * (numPage - 1);

            return Users.Skip(skiped).Take(itemPerPage);
        }

        public async ValueTask<ApplicationUser> GetOneAsync(string userName)
        {
            if (userName is null)
                throw new Exception("User Not Found");

            var user = await _userManager.FindByNameAsync(userName);
            if (user is null)
                throw new Exception("User Not Found");
            return user;
        }
        public async ValueTask<List<ApplicationUser>> GetAllUserAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}