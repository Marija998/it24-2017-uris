using Microsoft.EntityFrameworkCore;
using TransactionServiceAPI.Data;
using TransactionServiceAPI.Models;
using TransactionServiceAPI.Models.Dtos;

namespace TransactionServiceAPI.Repository
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Account> CreateAccountAsync(AccountCreateRequest createRequest)
        {
            var account = new Account
            {
                Currency = createRequest.Currency,
                IsActive = true,
                UserId = createRequest.UserId,
                Balance = 0
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeactivateAccountAsync(int accountNumber)
        {
            var account = await _context.Accounts.FindAsync(accountNumber);
            if (account == null)
            {
                return false; // Account not found
            }

            account.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAccountAsync(int accountNumber)
        {
            var account = await _context.Accounts.FindAsync(accountNumber);
            if (account == null || account.Balance != 0)
            {
                return false; // Account not found or balance is not zero
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Account> GetAccountByIdAsync(int accountNumber)
        {
            return await _context.Accounts.FindAsync(accountNumber);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> UpdateAccountAsync(int accountNumber, AccountUpdateRequest updateRequest)
        {
            var account = await _context.Accounts.FindAsync(accountNumber);
            if (account != null)
            {
                account.Balance = updateRequest.Balance;
                account.IsActive = updateRequest.IsActive;

                await _context.SaveChangesAsync();
            }

            return account;
        }
    }
}
