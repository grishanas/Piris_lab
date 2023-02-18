using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.classes;
using lab.db;

namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCodeController : ControllerBase
    {
        private readonly DBAccountCodeContext _context;

        public AccountCodeController(DBAccountCodeContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ICollection<Account_code> GetCodes()
        {
            return _context.codes.ToList();
        }

        [HttpPost]
        public async Task<IResult> AddCode([FromBody] Account_code code)
        {
            try
            {
                await _context.AddCode(code);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> DeleteCode([FromBody] string code)
        {
            try
            {
                await _context.DeleteCode(code);
            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }
}
