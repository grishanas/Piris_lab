using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.Transaction.BusinessLogic;
using lab.classes;
using lab.db;

namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMController : ControllerBase
    {

        private readonly CashInOut _context;
        public ATMController(CashInOut context)
        {
            _context = context;
        }

        [HttpPost("CashIn")]
        public async Task<IResult> CashIn(decimal money)
        {
            try
            {
                await _context.CashIn(money);
            }
            catch
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPost("CashOut")]
        public async Task<IResult> CashOut(decimal money)
        {
            try
            {
                        await _context.CashOut(money);
            }
            catch
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPost("CloseOperation")]
        public async Task<IResult> CloseOperation()
        {
            try
            {
                await _context.CloseOperation();
            }
            catch
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPost("TransferTo")]
        public async Task<IResult> TransferCash([FromBody] AccountID destination, decimal amount)
        {
            try
            {
                await _context.TransferCash(destination, amount);
            } catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

/*        [HttpPost("TransferFrom")]
        public async Task<IResult> TransferFromCash([FromBody] AccountID source,decimal amount)
        {
            try
            {
                await 
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }*/
        
    }
}
