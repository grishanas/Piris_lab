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

        public AccountController(DBAccountContext context)
        {
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
    }
}
