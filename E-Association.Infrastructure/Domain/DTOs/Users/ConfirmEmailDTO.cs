namespace Domain.DTOs.Users
{
    public class ConfirmEmailDTO
    {
        public string UserName { set; get; }
        public string ConfirmationCode { set; get; }
    }
}
