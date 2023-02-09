using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lab.db;
using lab.classes.client;

namespace lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DBClientContext _context;

        public ClientController(DBClientContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetClient([FromBody] string id)
        {
            var client = _context.GetClient(id);
            return Results.Json(client);
        }

        [HttpGet]
        public async Task<IResult> GetClents()
        {
            var clients= _context.GetClients();
            return Results.Json(clients);
        }

        [HttpPost("/AddClient")]
        public async Task<IResult> AddClient([FromBody] DBClient client)
        {
            try
            {

            }catch(Exception e)
            {

            }
            return Results.Ok();
        }

    }
}
