namespace E_Association.Service.IAssociationServices.Userservice
{
    public interface IAuthorizationService
    {
        ValueTask<string> CreateRoleAsync(string role);
        ValueTask<string> UpdateRoleAsync(string oldRole,string newRole);
        ValueTask<string> DeletRoleAsync(string role);
        ValueTask<string> AssignUserToRoleAsync(string userName, string role);
        ValueTask<string> DeleteUserFromRoleAsync(string userName, string role);
        ValueTask<string> UpdateUserRoleAsync(string userName,string oldRole, string roleNew);
        ValueTask<string> GetUserRoleAsync(string userName);
        ValueTask<List<string>> GetAllRoleAsync();
    }
}
