using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.classes;
using lab.db;

namespace lab.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class DBCitiesController : ControllerBase
    {
        private readonly DBCityContext _context;

        public DBCitiesController(DBCityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ICollection<City> GetCitiesAsync()
        {
            return _context.cities.ToList();
        }

        [HttpPost]
        public IResult AddCity([FromBody] string cityName)
        {
            try
            {
                if (cityName == null || cityName.Length > 50)
                    return Results.Problem();
                var city = new City();
                City last = _context.cities.OrderBy(p => p.id).LastOrDefault();
                if (last == null)
                {
                    city.id = 0;
                }
                else
                {
                    city.id = last.id + 1;
                }
                city.name = cityName;
                _context.Add(city);
                _context.SaveChanges();
            } catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete]
        public IResult DeleteCity([FromBody] int id)
        {
            try
            {
                var city = _context.cities.FirstOrDefault(p => p.id == id);
                if (city == null)
                    return Results.Problem();
                _context.cities.Remove(city);
                _context.SaveChanges();

            }catch(Exception E)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
    }
}
