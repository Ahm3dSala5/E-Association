namespace E_Association.Core.Features.Consumer.Query.Models
{
    public class UserModel
    {
        public string UserName { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public bool EmailConfirm { set; get; }
        public string Password { set; get; }
    }
}
