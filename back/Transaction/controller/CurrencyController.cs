using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.Transaction.BusinessLogic;
using lab.classes;
using lab.db;


namespace lab.Transaction.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly DBTypeOfCurrencyContext _context;

        public CurrencyController(DBTypeOfCurrencyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IResult> GetCitiesAsync()
        {
            return Results.Json(await _context.GetCurrencies());
        }

        [HttpPost]
        public async Task<IResult> AddCity([FromBody] type_of_currency cur)
        {
            try
            {
                await _context.AddCurrency(cur);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> DeleteCity([FromBody] type_of_currency cur)
        {
            try
            {
                await _context.DeleteCurrency(cur);

            }
            catch (Exception E)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }
}
