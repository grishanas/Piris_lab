using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.Transaction.BusinessLogic;
using lab.classes;
using lab.db;

namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly DBAccountContext _context;
        private readonly DepositLogic _depositController;
        private readonly DBAccountContext _dBAccountContext;

        public DepositController(DBAccountContext context, DBAccountContext dBAccountContext, DepositLogic depositLogic)
        {
            _context = context;
            _dBAccountContext = dBAccountContext;
            _depositController = depositLogic;
        }

        [HttpPost]
        public async Task<IResult> AddDeposit([FromBody] UserAccount userAccount)
        {

            try
            {
                await _depositController.AddDeposit(userAccount);

            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> GetDeposites()
        {
            try
            {
                

            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

    }
}
