using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using TransactionServiceAPI.Data;
using TransactionServiceAPI.Models;
using TransactionServiceAPI.Models.Dtos;
using TransactionServiceAPI.Repository;



namespace TransactionServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly MockUserService _mockUserService;

        public AccountController(IAccountService accountService, MockUserService mockUserService)
        {
            _accountService = accountService;
            _mockUserService = mockUserService;
        }


        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountById(int accountNumber)
        {
            var account = await _accountService.GetAccountByIdAsync(accountNumber);
            if (account == null)
            {
                return NotFound("Account not found.");
            }
            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateRequest accountCreateDto)
        {
            if (!_mockUserService.UserExists(accountCreateDto.UserId))
            {
                return BadRequest("User does not exist.");
            }

            var account = await _accountService.CreateAccountAsync(accountCreateDto);
            if (account == null)
            {
                return BadRequest("Unable to create account.");
            }
            return Ok(account);
        }

        [HttpDelete("{accountNumber}")]
        public async Task<IActionResult> DeleteAccount(int accountNumber)
        {
            var deleted = await _accountService.DeleteAccountAsync(accountNumber);
            if (!deleted)
            {
                return NotFound("Account not found or could not be deleted.");
            }
            return Ok("Account deleted successfully.");
        }

        [HttpPost("deactivate/{accountNumber}")]
        public async Task<IActionResult> DeactivateAccount(int accountNumber)
        {
            var account = await _accountService.GetAccountByIdAsync(accountNumber);
            if (account == null)
            {
                return NotFound("Account not found.");
            }
            var updateRequest = new AccountUpdateRequest();
            updateRequest.IsActive = false;
            updateRequest.Balance = account.Balance;
            
            await _accountService.UpdateAccountAsync(account.AccountNumber, updateRequest);
            return Ok("Account deactivated successfully.");
        }

        [HttpPost("deposit/{accountNumber}")]
        public async Task<IActionResult> Deposit(int accountNumber, [FromBody] decimal depositAmount)
        {
            var account = await _accountService.GetAccountByIdAsync(accountNumber);
            if (account == null)
            {
                return NotFound("Account not found.");
            }

            if (depositAmount <= 0)
            {
                return BadRequest("Deposit amount must be greater than zero.");
            }

            var updateRequest = new AccountUpdateRequest
            {
                Balance = account.Balance + depositAmount,
                IsActive = account.IsActive
            };

            await _accountService.UpdateAccountAsync(account.AccountNumber, updateRequest);

            return Ok("Deposit successful.");
        }
    }
}
