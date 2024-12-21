namespace Domain.DTOs.Users
{
    public class RegistrationDTO
    {
        public string UserName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
        public string Address { set; get; }
    }
}
