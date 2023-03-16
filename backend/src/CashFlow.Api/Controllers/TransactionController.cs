using CashFlow.Application.Interfaces;
using CashFlow.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionAppService _transactionAppService;

        public TransactionController(ITransactionAppService transactionAppService)
        {
            _transactionAppService= transactionAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransactionViewModel transactionViewModel)
        {
            var validation = await _transactionAppService.Add(transactionViewModel);

            return Ok(validation);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _transactionAppService.GetAllToday();

            return Ok(result);
        }
    }
}