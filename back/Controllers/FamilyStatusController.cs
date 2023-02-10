using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lab.classes;
using lab.db;

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyStatusController : ControllerBase
    {
        private DBFamilyStatusContext _context { get; set; }


        public FamilyStatusController(DBFamilyStatusContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IResult> GetFamilyStatuses()
        {
            try
            {
                var res= Results.Json(_context.familyStatuses.ToList(),statusCode: 200);
                return res;

            } catch (Exception e)
            {
                return Results.Problem();

            }
     
        }

        [HttpPost]
        public async Task<IResult> AddFamilyStatus([FromBody] FamilyStatus familyStatus)
        {
            try
            {
                await _context.AddFamilyStatus(familyStatus);

            } 
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> DeleteFamilyStatus([FromBody] FamilyStatus familyStatus)
        {
            try
            {
                await _context.DeleteFamilyStatus(familyStatus);
            } catch (Exception e)
            {

            }
            return Results.Ok();
        }

        [HttpPatch]
        public async Task<IResult> UpdateFamilyStatus([FromBody] FamilyStatus familyStatus)
        {
            try
            {
                await _context.UpdateFamilyStatus(familyStatus);
            }catch(Exception e)
            {
                return Results.Problem(statusCode: 404, detail: "not found");
            }
            return Results.Ok();
        }

    }
}
