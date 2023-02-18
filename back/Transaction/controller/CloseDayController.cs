using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.Transaction.BusinessLogic;
using lab.classes;
using lab.db;
namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloseDayController : ControllerBase
    {
        private readonly CloseDay _closeDayContext;

        public CloseDayController(CloseDay context)
        {
            _closeDayContext = context;
        }

        [HttpPost("CloseDay")]
        public async Task<IResult> CloseDay()
        {
            try
            {
                await _closeDayContext.Closeday();
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }
}
