using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.Logic;
using lab.classes;

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardLogic _context;

        public CreditCardController(CreditCardLogic context)
        {
            _context = context;
        }

        [HttpPost("CreateCard")]
        public async Task<IResult> CreateCard([FromBody] CreateCreditCard user)
        {
            try
            {
                await _context.CreateCreditCard(user);
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        
        [HttpPost("LogIn")]
        public async Task<IResult> LogIn([FromBody]UserCreditCard user,string password)
        {
            try
            {
                var acc = await _context.LogIn(user, password);
                return Results.Json(new AccountID() { account_code=acc.account_code,account_id=acc.account_id});
            }catch(Exception)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }


}
