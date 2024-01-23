using TransactionServiceAPI.Models;
using TransactionServiceAPI.Models.Dtos;

namespace TransactionServiceAPI.Repository
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(AccountCreateRequest createRequest);
        Task<Account> UpdateAccountAsync(int accountNumber, AccountUpdateRequest updateRequest);
        Task<Account> GetAccountByIdAsync(int accountNumber);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<bool> DeleteAccountAsync(int accountNumber);

        Task<bool> DeactivateAccountAsync(int accountNumber);
    }
}
