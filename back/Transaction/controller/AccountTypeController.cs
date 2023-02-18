using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.classes;
using lab.db;

namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly DBAccountTypeContext _context;

        public AccountTypeController(DBAccountTypeContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ICollection<Account_type> GetCodes()
        {
            return _context.types.ToList();
        }

        [HttpPost]
        public async Task<IResult> AddCode([FromBody] Account_type code)
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
        public async Task<IResult> DeleteCode([FromBody] int code)
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
