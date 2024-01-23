using TransactionServiceAPI.Models;
using TransactionServiceAPI.Models.Dtos;

namespace TransactionServiceAPI.Repository
{
    public interface ITransactionService
    {
        Task<Transaction> CreateTransactionAsync(TransactionCreateRequest createRequest);
        Task<Transaction> GetTransactionByIdAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    }
}
