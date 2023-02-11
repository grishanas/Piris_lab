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
            var clients= await _context.GetClients();
            return Results.Json(clients);
        }


        #region Add client information

/*        [HttpPost("/AddDBClient")]
        public async Task<IResult> AddClient([FromBody] DBClient client)
        {
            try
            {
                


            }catch(Exception e)
            {

            }
            return Results.Ok();
        }*/
        [HttpPost("/AddClient")]
        public async Task<IResult> AddClient([FromBody] Client client)
        {
            try
            {
                await _context.AddClient(client);

            }
            catch (Exception e)
            {

            }
            return Results.Ok();
        }
        #endregion

        #region Delete client

        [HttpDelete]
        public async Task<IResult> DeleteClient([FromBody] string id)
        {
            try
            {
                await _context.DeleteClient(id);
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }
        #endregion

        [HttpPatch]
        public async Task<IResult> UpdateClient([FromBody] DBClient client)
        {
            try
            {

                _context.UpdateClient(client);
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

    }
}
