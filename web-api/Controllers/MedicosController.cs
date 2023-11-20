using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace web_api.Controllers
{
    public class MedicosController : ApiController
    {
        Repositories.Medico _repositories;

        public MedicosController()
        {
            _repositories = new Repositories.Medico(Configurations.Databases.getConnectionString());
        }


        // GET: api/Medicos
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                List<Models.Medico> medicos = await _repositories.Get();
                if (medicos.Count <= 0)
                    return NotFound();
                return Ok(medicos);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // GET: api/Medicos/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                Models.Medico medico = await _repositories.Get(id);
                if (medico.Id == 0)
                    return NotFound();
                return Ok(medico);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Medicos
        public async Task<IHttpActionResult> Post([FromBody] Models.Medico medico)
        {
            try
            {
                int id = await _repositories.Post(medico);
                medico.Id = id;
                return Ok(medico);
            } 
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        // PUT: api/Medicos/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Medico medico)
        {
            if(id != medico.Id)
                return BadRequest();

            int res = await _repositories.Put(medico);
            if (res <= 0)
                return NotFound();

            medico.Id = id;
            return Ok(medico);
        }

        // DELETE: api/Medicos/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            int res = await _repositories.Delete(id);
            if (res <= 0)
                return NotFound();
            return Ok();
        }
    }
}
