namespace Domain.DTOs.Users
{
    public class UserDTO
    {
        public string? UserName { get; set; }
        public string? Password { set; get; }
        public string? Email { set; get; }
        public bool? EmailConfirmed { set; get; }
        public string? Address { set; get; }
        public string? BalanceId { set; get; }
    }
}
