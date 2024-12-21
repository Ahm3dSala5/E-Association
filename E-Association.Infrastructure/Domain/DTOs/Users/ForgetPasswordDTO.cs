namespace Domain.DTOs.Users
{
    public class ForgetPasswordDTO
    {
        public string Email { get; set; }
        public string verificationCode { set; get; }
        public string NewPassword { set; get; }
    }
}
