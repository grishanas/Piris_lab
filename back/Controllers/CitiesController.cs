using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.classes;
using lab.db;

namespace lab.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly DBCityContext _context;

        public CitiesController(DBCityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ICollection<City> GetCitiesAsync()
        {
            return _context.Cities.ToList();
        }

        [HttpPost]
        public async Task<IResult> AddCity([FromBody] City city)
        {
            try
            {
                await _context.AddCity(city);
                
            } catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete]
        public async Task<IResult> DeleteCity([FromBody] City city)
        {
            try
            {
               await _context.DeleteCity(city);

            }catch(Exception E)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPatch]
        public async Task<IResult> updateCity([FromBody] City city)
        {
            try
            {
               await _context.UpdateCity(city);
            }
            catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }
}
