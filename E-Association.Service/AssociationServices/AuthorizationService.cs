using System.Data;
using Domain.Entities.Securities;
using E_Association.Service.IAssociationServices.Userservice;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Association.Service.AssociationServices.Userservice
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthorizationService(RoleManager<ApplicationRole> _userManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = _userManager;
            this.userManager = userManager;
        }
        public async ValueTask<string> AssignUserToRoleAsync(string userName, string role)
        {
            if (userName is null || role is null)
                throw new ArgumentNullException("Invalid Data");

            var chekRole = await roleManager.FindByNameAsync(role);
            var checkUser = await userManager.FindByNameAsync(userName);
            if(chekRole is null || checkUser is null)
                throw new Exception("Role or User are Not Found");

            var addedResult = await userManager.AddToRoleAsync(checkUser, role);
            return addedResult.Succeeded is true ? "User added To Role Successfuly" : "Invalid Added";
        }

        public async ValueTask<string> CreateRoleAsync(string role)
        {
            if (role is null)
                throw new ArgumentNullException("Invalid Data");

            var applicationRole = new ApplicationRole() { Name = role };
            var result =  await roleManager.CreateAsync(applicationRole);

            return result.Succeeded ? "Role Created Successfuly" : "Invalid Creation";
        }

        public async ValueTask<string> DeleteUserFromRoleAsync(string userName, string role)
        {
            if (role is null || userName is null)
                throw new ArgumentNullException("Invalid Data");

            var chekRole = await roleManager.FindByNameAsync(role);
            var checkUser = await userManager.FindByNameAsync(userName);
            if (chekRole is null || checkUser is null)
                throw new Exception("Role or User are Not Found");

            var result = await userManager.RemoveFromRoleAsync(checkUser, role);
            return result.Succeeded is true ? "User are Delete From Role Successfuly" : "Invalid Deleted";

        }

        public async ValueTask<string> DeletRoleAsync(string role)
        {
            if (role is null)
                throw new ArgumentNullException("Invalid Data");

            var roleExisiting = await roleManager.FindByNameAsync(role);
            if (roleExisiting is null)
                throw new Exception("Role are Not Found");

            var deletedResult = await roleManager.DeleteAsync(roleExisiting);
            return deletedResult.Succeeded is true ? "Role are Delete Successfuly" : "Invalid Deleted";
        }

        public async ValueTask<List<string>> GetAllRoleAsync()
        {
            var roles = await roleManager.Roles.ToListAsync();
            if (roles is null)
                throw new Exception("Roles List is Emoty");

            return roles.Select(x=>x.Name).ToList()!;

        }

        public async ValueTask<string> GetUserRoleAsync(string userName)
        {
            if (userName is null)
                throw new ArgumentNullException("Invalid Data");

            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
                throw new Exception("Roles List is Emoty");

            var role = await userManager.GetRolesAsync(user);
            return role is null ? "User Not Have any Role" : role.First();
        }

        public async ValueTask<string> UpdateRoleAsync(string oldRole, string newRole)
        {
            if (oldRole is null || newRole is null)
                throw new ArgumentNullException("Invalid Data");

            var role = await  roleManager.FindByNameAsync(oldRole);
            if (role is null)
                throw new Exception("Role Not Found");

            role.Name = newRole;
            return "Updated Successfuly";
        }

        public async ValueTask<string> UpdateUserRoleAsync(string userName, string oldRole,string newRole)
        {
            if (newRole is null || userName is null)
                throw new ArgumentNullException("Invalid Data");

            var user = await userManager.FindByNameAsync(newRole);
            var role = await roleManager.FindByNameAsync(userName);
            if (user is null || role is null)
                throw new Exception("Role or User are Not Found");

            var addedResult = await userManager.AddToRoleAsync(user,newRole);
            var result = await userManager.RemoveFromRoleAsync(user, oldRole);

            return (addedResult.Succeeded is true && result.Succeeded) ?
                                "User Role are Updated Successfuly" : "Invalid Update";
        }
    }
}