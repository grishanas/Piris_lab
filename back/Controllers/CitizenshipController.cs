using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.classes;
using lab.db;

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenshipController : ControllerBase
    {
        private DBCitezenshipContext _context { get; set; }


        public CitizenshipController(DBCitezenshipContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IResult> GetCitizenships()
        {
            try
            {
                var res = Results.Json(_context.GetCitizenships(), statusCode: 200) ;
                return res;

            }
            catch (Exception e)
            {
                return Results.Problem();

            }

        }

        [HttpPost]
        public async Task<IResult> AddCitizenship([FromBody] Citizenship citizenship)
        {
            try
            {
                await _context.AddCitezenship(citizenship);

            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> DeleteCitizenship([FromBody] Citizenship citizenship)
        {
            try
            {
                await _context.DeleteCitezenship(citizenship);
            }
            catch (Exception e)
            {

            }
            return Results.Ok();
        }

        [HttpPatch]
        public async Task<IResult> UpdateFamilyStatus([FromBody] Citizenship citizenship)
        {
            try
            {
                await _context.UpdateCitezenship(citizenship);
            }
            catch (Exception e)
            {
                return Results.Problem(statusCode: 404, detail: "not found");
            }
            return Results.Ok();
        }
    }

}
