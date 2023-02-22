using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.Transaction.BusinessLogic;
using lab.classes;
using lab.db;

namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly CreditLogic _context;
        public CreditController(CreditLogic context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IResult> AddCredit([FromBody] UserAccount userAccount,decimal amount)
        {
            try
            {
                await _context.CreareCredit(userAccount, amount);
            }
            catch(Exception e)
            {
                return Results.Problem();
            }

            return Results.Ok();
        }
        [HttpPost("CashOut")]
        public async Task<IResult> CashOut([FromBody] UserAccountID user,decimal amount)
        {
            try
            {
                await _context.CashOut(user, amount);
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok(amount);
        }
    }
}
