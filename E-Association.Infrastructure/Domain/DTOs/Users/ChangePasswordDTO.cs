namespace Domain.DTOs.Users
{
    public class ChangePasswordDTO
    {
        public string Email { set; get; }
        public string oldPassword { set; get; }
        public string newPassword { set; get; }
        public string confirmNewPassword { set; get; }
    }
}
