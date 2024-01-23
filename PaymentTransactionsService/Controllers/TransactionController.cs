using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransactionServiceAPI.Data;
using TransactionServiceAPI.Models;
using System.Globalization;
using TransactionServiceAPI.Models.Dtos;
using TransactionServiceAPI.Repository;

namespace TransactionServiceAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        private readonly ProductServiceClient _productServiceClient;

        public TransactionController(ITransactionService transactionService, IAccountService accountService, ProductServiceClient productServiceClient)
        {
            _transactionService = transactionService;
            _accountService = accountService;
            _productServiceClient = productServiceClient;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionCreateRequest createRequest)
        {
            var product = await _productServiceClient.GetProductByIdAsync(createRequest.ProductId);
            if (product == null || !product.IsAvailable)
            {
                return BadRequest("Product is not available or doesn't exist.");
            }

            // Check if Source and Destination accounts have the same currency
            var sourceAccount = await _accountService.GetAccountByIdAsync(createRequest.SourceAccount);
            var destinationAccount = await _accountService.GetAccountByIdAsync(createRequest.DestinationAccount);

            if (sourceAccount == null || destinationAccount == null)
            {
                return BadRequest("One of the accounts does not exist.");
            }

            decimal amountToDeduct = createRequest.TransactionAmount;
            if (sourceAccount.Currency != destinationAccount.Currency)
            {
                amountToDeduct = CurrencyExchange.Convert(createRequest.TransactionAmount, sourceAccount.Currency, destinationAccount.Currency);
            }

            // Check if the source account has enough balance
            if (sourceAccount.Balance < amountToDeduct)
            {
                var failedCreateRequest = new TransactionCreateRequest
                {
                    SourceAccount = createRequest.SourceAccount,
                    DestinationAccount = createRequest.DestinationAccount,
                    Date = createRequest.Date,
                    TransactionAmount = createRequest.TransactionAmount,
                    TransactionStatus = createRequest.TransactionStatus,
                };
                await _transactionService.CreateTransactionAsync(failedCreateRequest);
                return BadRequest("Insufficient funds in the source account.");
            }

            // If the source account has enough balance
            var sourceUpdateRequest = new AccountUpdateRequest
            {
                Balance = sourceAccount.Balance - amountToDeduct,
                IsActive = sourceAccount.IsActive
            };

            var destinationUpdateRequest = new AccountUpdateRequest
            {
                Balance = destinationAccount.Balance + createRequest.TransactionAmount,
                IsActive = destinationAccount.IsActive
            };

            await _accountService.UpdateAccountAsync(sourceAccount.AccountNumber, sourceUpdateRequest);
            await _accountService.UpdateAccountAsync(destinationAccount.AccountNumber, destinationUpdateRequest);

            var transaction = await _transactionService.CreateTransactionAsync(createRequest);


            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null)
            {
                return NotFound($"Transaction with ID {id} not found.");
            }
            return Ok(transaction);
        }

    }

    internal class CurrencyExchange
    {
        private const string endpoint = @"http://currencies.apps.grandtrunk.net/getlatest/{0}/{1}";
        private static HttpClient httpClient = new HttpClient();
        public static decimal Convert(decimal amount, string from, string to)
        {
            return amount * GetExchangeRate(from, to);
        }
        public static decimal GetExchangeRate(string from, string to)
        {
            string url = string.Format(endpoint, from, to);
            return decimal.Parse(httpClient.GetStringAsync(url).GetAwaiter().GetResult(), NumberFormatInfo.InvariantInfo);
        }
    }
}
