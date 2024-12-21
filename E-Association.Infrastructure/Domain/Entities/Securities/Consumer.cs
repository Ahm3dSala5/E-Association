using Domain.Entities.Business;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities.Securities
{
    public class Consumer : IdentityUser<Guid>
    {
        public string Address { set; get; }
        public ICollection<Deposit> Deposites { set; get; } = new List<Deposit>();
        public ICollection<Association> SubScriptions { set; get; } = new List<Association>();
        public ICollection<ConsumerAssociations> UserSubscriptions { set; get; } = new List<ConsumerAssociations>();
        public ICollection<Withdrawals> Withdrawals { set; get; } = new List<Withdrawals>();
        public ICollection<Payment> Payments { set; get; } = new List<Payment>();
        public ICollection<Notifications> Notifications { set; get; } = new List<Notifications>();
        public ICollection<Transactions> Transactions { set; get; } = new List<Transactions>();
        public Balance Balance { set; get; }
        public Guid  BalanceId { set; get; }

        public virtual ICollection<IdentityUserRole<Guid>> UserRoles { get; set; } = new List<IdentityUserRole<Guid>>();
        public virtual ICollection<IdentityUserClaim<Guid>> Claims { get; set; } = new List<IdentityUserClaim<Guid>>();
        public virtual ICollection<IdentityUserLogin<Guid>> Logins { get; set; } = new List<IdentityUserLogin<Guid>>();
        public virtual ICollection<IdentityUserToken<Guid>> Tokens { get; set; } = new List<IdentityUserToken<Guid>>();
    }
}
