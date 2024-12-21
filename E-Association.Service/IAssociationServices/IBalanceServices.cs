using Domain.Entities.Business;

namespace E_Association.Service.IAssociationServices.IBalanceServices
{
    public interface IBalanceServices
    {
        ValueTask<string> CreateBalanceAsync(Balance balance);
        ValueTask<string> UpdateUserPalanceAsync(Balance newBalance);
        ValueTask<string> DeleteUserBalance(Guid userId);
        ValueTask<Balance> GetUserBalance(Guid userId);
        ValueTask<List<Transactions>> GetBalanceTransactions(Guid balanceId);
        ValueTask<Balance> GetBalanceDetails(Guid balanceId);
    }
}
