using Domain.Entities.Business;
using E_Association.Core.Domain.Enums;
using E_Association.Infrastructure.Domain.DTOs.Withdrawal;
using MediatR;

namespace E_Association.Core.Features.Withdrawal.Command.Request
{
    public class UpdateWithdrawalCommand :IRequest<string>
    {
        public UpdateWithdrawalCommand(WithdrawalDTO withdrawal)
        {
            this.Amount = withdrawal.Amount;
            this.Status = withdrawal.Status;
            this.UserId = withdrawal.UserId;
            this.WithdrawalAt = withdrawal.WithdrawalAt;
        }
        public decimal Amount { set; get; }
        public WithdrawalsStatus Status { set; get; }
        public DateTime WithdrawalAt { set; get; }
        public Guid? UserId { set; get; }
    }
}
