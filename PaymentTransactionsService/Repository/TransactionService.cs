using Microsoft.EntityFrameworkCore;
using TransactionServiceAPI.Data;
using TransactionServiceAPI.Models;
using TransactionServiceAPI.Models.Dtos;

namespace TransactionServiceAPI.Repository
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Transaction> CreateTransactionAsync(TransactionCreateRequest createRequest)
        {
            var transaction = new Transaction
            {
                SourceAccount = createRequest.SourceAccount,
                DestinationAccount = createRequest.DestinationAccount,
                Date = createRequest.Date,
                TransactionAmount = createRequest.TransactionAmount,
                TransactionStatus = createRequest.TransactionStatus
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
        {
            return await _context.Transactions.FindAsync(transactionId);
        }
    }
}
