using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace web_api.Controllers
{
    public class ClienteController : ApiController
    {
        public Repositories.Cliente _rep;

        public ClienteController()
        {
            _rep = new Repositories.Cliente(Configurations.Databases.getConnectionString());
        }


        // GET: api/Cliente
        public IHttpActionResult Get()
        {
            try
            {
                List<Models.Cliente> clientes = new List<Models.Cliente>();
                clientes = _rep.GetAll();
                return Ok(clientes);
            } catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        // GET: api/Cliente/5
        public IHttpActionResult Get(int id)
        {
            Models.Cliente c = _rep.GetById(id);
            return Ok(c);
        }

        // POST: api/Cliente
        public IHttpActionResult Post([FromBody]Models.Cliente cliente)
        {
            int id = _rep.Add(cliente);
            cliente.Id = id;
            return Ok(cliente);

        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
