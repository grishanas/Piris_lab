using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.Transaction.BusinessLogic;
using lab.classes;
using lab.db;

namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DBAccountContext _context;
        private readonly DBBalanceContext _dBBalanceContext;

        public AccountController(DBAccountContext context, DBBalanceContext dBBalanceContext)
        {
            _dBBalanceContext=dBBalanceContext;
            _context = context;
        }

        [HttpPost("api/AccountController/CreateAccount")]
        public async Task<IResult> CreateAccount([FromBody]UserAccount user_data)
        {
            try
            {
                var acc = await _context.CreateAccount(user_data);


            }
            catch
            {
                return Results.Problem();
            }
            return Results.Ok();

        }

        [HttpGet("GetAccounts")]
        public async Task<IResult> GetAccounts()
        {
            try
            {
                return Results.Json(await _context.GetAccounts());
            }catch(Exception e)
            {
                return Results.Problem();
            }
        }

        [HttpPost("GetBalances")]
        public async Task<IResult> GetBalances([FromBody] UserAccountID user)
        {
            try
            {
                return Results.Json(await _dBBalanceContext.GetAllBalances(new AccountID(user)));

            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }
}
