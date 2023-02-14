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
        public async Task<IResult> GetClient([FromRoute] string id)
        {
            var client = await _context.GetClient(id);
            return Results.Json(client);
        }

        [HttpGet]
        public async Task<IResult> GetClents()
        {
            var clients= await _context.GetClients();
            return Results.Json(clients);
        }


        #region Add client information


        [HttpPost("/AddM2MDisability")]
        public async Task<IResult> AddDisability([FromBody] m2m_client_Disabilities disability)
        {
            try
            {
                await _context.AddDisabilities(disability);

            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPost("/AddM2MFamily")]
        public async Task<IResult> AddFAmilyStatus([FromBody] m2m_client_family item)
        {
            try
            {
                await _context.AddFamilyStatus(item);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPost("/AddM2MLive")]
        public async Task<IResult> AddM2MLive([FromBody] m2m_client_live item)
        {
            try
            {
                await _context.AddCitiesOfLive(item);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPost("/AddM2MResidence")]
        public async Task<IResult> AddM2MResidence([FromBody] m2m_client_residence item)
        {
            try
            {
                await _context.AddCitiesOfResidence(item);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpPost("/AddM2MCitezenship")]
        public async Task<IResult> AddCitezenship([FromBody] m2m_client_citezenship item)
        {
            try
            {
                await _context.AddCitizenships(item);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }


        [HttpPost("/AddClient")]
        public async Task<IResult> AddClient([FromBody] DBClient client)
        {
            try
            {
                await _context.AddClient(client);

            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
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

        #region Delete Client Information

        [HttpDelete("/DeleteM2MDisability")]
        public async Task<IResult> DelteDisability([FromBody] m2m_client_Disabilities disability)
        {
            try
            {
                await _context.Deletem2mDis(disability);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete("/DeleteM2MFamily")]
        public async Task<IResult> DelteFamilyStatus([FromBody] m2m_client_family family)
        {
            try
            {
                await _context.Deletem2mClients(family);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete("/DeleteM2MLive")]
        public async Task<IResult> DelteM2MLive([FromBody] m2m_client_live live)
        {
            try
            {
                await _context.Deletem2mLives(live);

            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete("/DelteM2MResidence")]
        public async Task<IResult> DelteM2MResidence([FromBody] m2m_client_residence residence)
        {
            try
            {
                await _context.Deletem2mClientResidence(residence);
            }
            catch (Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

        [HttpDelete("/DelteM2MCitizenship")]
        public async Task<IResult> DelteM2MCitizenship([FromBody] m2m_client_citezenship citezenship)
        {
            try
            {
                await _context.Deletem2mCitezenship(citezenship);
            }
            catch (Exception e)
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

                await _context.UpdateClient(client);
            }catch(Exception e)
            {
                return Results.Problem();
            }
            return Results.Ok();
        }

    }
}
