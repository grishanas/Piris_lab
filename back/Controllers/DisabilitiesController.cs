using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab.classes;
using lab.db;

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisabilitiesController : ControllerBase
    {
        private DBDisabilitiesContext _context { get; }

        public DisabilitiesController(DBDisabilitiesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IResult> GetDisabilities()
        {
            try
            {
                return Results.Json(_context.Disabilities.ToList(), statusCode: 200);
            }
            catch (Exception e)
            {
                return Results.Problem();
            }
        }
        [HttpPost]
        public async Task<IResult> AddDisability([FromBody] Disabilities disability)
        {
            try
            {
                await _context.AddDisability(disability);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();

        }

        [HttpDelete]
        public async Task<IResult> DeleteDisability([FromBody] Disabilities disability)
        {
            try
            {
                await _context.DeleteDisability(disability);
            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        public async Task<IResult> UpdateDisability([FromBody] Disabilities disability)
        {
            try
            {
                await _context.UpdateDisability(disability);
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }
}
