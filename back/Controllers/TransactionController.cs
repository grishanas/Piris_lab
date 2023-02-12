using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.TransactionController;
namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly AccountTransactionController _context;

        public TransactionController(AccountTransactionController context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IResult> CashOut()
        {
            return Results.Json(await _context.CashOut());
        }
    }
}
