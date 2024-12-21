namespace Domain.DTOs.Users
{
    public class UpdateUserPasswordDTO
    {
        public string UserName { set; get; }
        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string ConfirmPassword { set; get; }
    }
}
